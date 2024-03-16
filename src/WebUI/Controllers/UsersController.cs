﻿using AutoMapper;
using Contact_zoo_at_home.Application;
using Contact_zoo_at_home.Core.Entities.Users;
using Contact_zoo_at_home.Core.Entities.Users.IndividualUsers;
using Contact_zoo_at_home.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using WebUI.Models.User;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebUI.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly IUserStore<ApplicationIdentityUser> _userStore;
        private readonly IMapper _mapper;

        private const string c_profileSettingsAddress = "Settings/ProfileSettings";

        public UsersController(ILogger<UsersController> logger, 
            SignInManager<ApplicationIdentityUser> signInManager, 
            UserManager<ApplicationIdentityUser> userManager, 
            IUserStore<ApplicationIdentityUser> userStore, 
            IMapper mapper)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _mapper = mapper;
        }

        private ApplicationIdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationIdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationIdentityUser)}'. " +
                    $"Ensure that '{nameof(ApplicationIdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private async Task<UserProfileDTO> LoadUserDTOByIdAsync(int id)
        {
            BaseUser user = await UserManagement.GetUserProfileInfoByIdAsync(id);

            switch (user) // hierarchy mapping?!
            {
                case CustomerUser:
                    return _mapper.Map<UserProfileDTO>(user);
                case IndividualPetOwner:
                    return _mapper.Map<IndividualPetOwnerUserProfileDTO>(user);
                default:
                    throw new NotImplementedException();
            }
        }

        private BaseUser DTOToBaseUser(UserProfileDTO profile)
        {
            BaseUser user;
            switch (profile)
            {
                case IndividualPetOwnerUserProfileDTO:
                    user = _mapper.Map<IndividualPetOwner>(profile);
                    break;
                case UserProfileDTO:
                    user = _mapper.Map<CustomerUser>(profile);
                    break;
                default:
                    throw new NotImplementedException(nameof(profile));
            }
            return user;
        }

        private async Task<IActionResult> SaveNewProfileSettings(UserProfileDTO profile)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return BadRequest($"Unable to load user with ID '{userId}'.");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Data not valid");
                return View(c_profileSettingsAddress, profile);
            }
            BaseUser baseUser = DTOToBaseUser(profile);
            baseUser.Id = Convert.ToInt32(userId);
            var task = UserManagement.SaveUserProfileChangesAsync(baseUser);

            await _signInManager.RefreshSignInAsync(await _userManager.GetUserAsync(User));
            await task;

            profile.StatusMessage = "Your profile has been updated";
            return View(c_profileSettingsAddress, profile);
        }

        [Route("Users/Settings/Profile")]
        public IActionResult Profile()
        {
            return View("Settings/Profile");
        }

        [Route("Users/Settings/ProfileSettings")]
        public async Task<IActionResult> ProfileSettings()
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return BadRequest($"Unable to load user with ID '{userId}'.");
            }

            UserProfileDTO profile = await LoadUserDTOByIdAsync(Convert.ToInt32(userId));
            return View(c_profileSettingsAddress, profile);
        }

        [Route("Users/Settings/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View("Settings/ChangePassword");
        }

        [HttpPost]
        public async Task<IActionResult> TryToChangeProfileSettings(UserProfileDTO profile)
        {
            return await SaveNewProfileSettings(profile);
        }

        [HttpPost]
        public async Task<IActionResult> TryToChangeProfileSettings_IndividualPetOwner(IndividualPetOwnerUserProfileDTO profile)
        {
            return await SaveNewProfileSettings(profile);
        }

        [HttpPost]
        public async Task<IActionResult> TryToChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return ChangePassword();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, changePasswordModel.OldPassword, changePasswordModel.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return ChangePassword();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            changePasswordModel.StatusMessage = "Your password has been changed.";

            return View("Settings/ChangePassword", changePasswordModel);
        }

    }
}

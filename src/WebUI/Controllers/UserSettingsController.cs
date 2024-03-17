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
    public class UserSettingsController : Controller
    {
        private readonly ILogger<UserSettingsController> _logger;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly IUserStore<ApplicationIdentityUser> _userStore;
        private readonly IMapper _mapper;

        public UserSettingsController(ILogger<UserSettingsController> logger, 
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
                return View("ProfileSettings", profile);
            }
            BaseUser baseUser = DTOToBaseUser(profile);
            baseUser.Id = Convert.ToInt32(userId);
            var task = UserManagement.SaveUserProfileChangesAsync(baseUser);

            await _signInManager.RefreshSignInAsync(await _userManager.GetUserAsync(User));
            await task;
            _logger.LogInformation("User information was updated.");

            profile.StatusMessage = "Your profile has been updated";
            return View("ProfileSettings", profile);
        }

        [Route("User/Settings/Profile")]
        public IActionResult Profile()
        {
            return View("Profile");
        }

        [Route("User/Settings/ProfileSettings")]
        public async Task<IActionResult> ProfileSettings()
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return BadRequest($"Unable to load user with ID '{userId}'.");
            }

            UserProfileDTO profile = await LoadUserDTOByIdAsync(Convert.ToInt32(userId));
            return View("ProfileSettings", profile);
        }

        [Route("User/Settings/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View("ChangePassword");
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

            return View("ChangePassword", changePasswordModel);
        }

    }
}
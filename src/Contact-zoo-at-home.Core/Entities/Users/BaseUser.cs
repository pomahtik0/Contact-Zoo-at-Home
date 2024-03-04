﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_zoo_at_home.Core.Entities.Users
{
    /// <summary>
    /// Base class for all registered users.
    /// </summary>
    public abstract class BaseUser
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public byte[] ProfileImage { get; set; } = [];
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }

        #region Rating

        public decimal Rating { get; private set; }
        public int RatedBy { get; private set; }

        public decimal AddToRating(decimal addingRateMark) // ToDo: Check calculations
        {
            if (RatedBy == 0)
            {
                this.Rating = addingRateMark;
            }
            else
            {
                this.Rating = (this.Rating + addingRateMark / RatedBy) * ((decimal)RatedBy / RatedBy + 1);
            }

            RatedBy++;
            return this.Rating;
        }

        #endregion

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_zoo_at_home.Infrastructure.Data
{
    public static class ConstantsForEFCore
    {
        public static class TableNames
        {

        }

        public static class Sizes
        {
            public const int userNameLength = 32;

            public const int profileImageMax = 1024 * 1024; // up to one mb photo

            public const int emailLenght = 256;

            public const int phoneNumberLength = 20;

            public const int shortTitlesLength = 50;

            public const int shortDescriptionLength = 400;

            public const int descriptionLength = 4096;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gymify.Web.Infrastructure
{
    public static class Policies
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string RegularUser = "RegularUser";
    }
}

﻿using Microsoft.AspNetCore.Identity;
using System;

namespace StudentManagementAPI.Models
{
    public class AppRole:IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}

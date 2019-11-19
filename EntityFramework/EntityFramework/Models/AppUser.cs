﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class AppUser:IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Indentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Indentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

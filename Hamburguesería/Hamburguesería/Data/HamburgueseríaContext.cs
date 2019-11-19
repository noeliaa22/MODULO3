using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hamburguesería.Models;

    public class HamburgueseríaContext : DbContext
    {
        public HamburgueseríaContext (DbContextOptions<HamburgueseríaContext> options)
            : base(options)
        {
        }
        public DbSet<Hamburguesería.Models.Menu> Menus { get; set; }
        public DbSet<Hamburguesería.Models.Principal> Principales { get; set; }
        public DbSet<Hamburguesería.Models.Entrante> Entrantes { get; set; }
        public DbSet<Hamburguesería.Models.Postre> Postres { get; set; }


    }

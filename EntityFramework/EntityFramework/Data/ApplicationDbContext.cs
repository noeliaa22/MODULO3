using System;
using System.Collections.Generic;
using System.Text;
using EntityFramework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Autobiografia> AutoBiografias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ObraCategoria> ObraCategorias { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
    }
}

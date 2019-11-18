using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EjercicioVideoclub.Models;

public class VideoclubContext : DbContext
{
    public VideoclubContext(DbContextOptions<VideoclubContext> options)
        : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserFilm> UsersFilms { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioVideoclub.Models
{
    public class Film
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Title { get; set; }
        public string Synopsis { get; set; }
        [MaxLength(25)]
        [Required]
        public string Genre { get; set; }
        public string Image { get; set; }
        public string Rented { get; set; }
        public List<UserFilm> UserFilm { get; set; }
    }
}

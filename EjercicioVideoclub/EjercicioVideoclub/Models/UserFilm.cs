using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioVideoclub.Models
{
    public class UserFilm
    {

        public int Id { get; set; }
        public DateTime DataRental { get; set; }
        public DateTime? ReturnDate { get; set; }
        public User User { get; set; }
        public Film Film { get; set; }
    }
}

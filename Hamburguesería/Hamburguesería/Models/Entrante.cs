using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburguesería.Models
{
    public class Entrante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IngredientesPrincipales { get; set; }
        public string Imagen { get; set; }
        public double Precio { get; set; }
    }
}

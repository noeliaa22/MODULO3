using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburguesería.Models.ViewModels
{
    public class CrearMenuVM
    {
        public Menu Menu { get; set; }
        public List<Principal> Principales { get; set; }
        public List<Entrante> Entrantes { get; set; }
        public List<Postre> Postres { get; set; }
    }
}

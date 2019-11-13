using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class EmpleadosController : Controller
    {
            List<Empleado> trabajadores = new List<Empleado>
            {
                new Empleado{
                    Id = 1,
                Nombre = "Noelia",
                Apellido = "Minguez",
                FechaNacimiento = Convert.ToDateTime("18/10/1996"),
                Imagen = "https://imagenes-amor.net/wp-content/uploads/2018/04/oso_panda_kawaii_imagen_amor-800x800.jpg"
                },
                new Empleado
                {
                Id = 2,
                Nombre = "Cepe",
                Apellido = "Lopez",
                FechaNacimiento = Convert.ToDateTime("15/11/1958"),
                Imagen = "https://www.emojirequest.com/images/SalutingEmoji.jpg"

                },
                new Empleado
                {
                 Id = 3,
                Nombre = "Juani",
                Apellido = "Perez",
                FechaNacimiento = Convert.ToDateTime("12/12/1943"),
                Imagen = "https://www.adslzone.net/app/uploads/2019/03/emoji-loco.jpg"

                },
                  new Empleado
                {
                 Id = 4,
                Nombre = "Antonio",
                Apellido = "Mendez",
                FechaNacimiento = Convert.ToDateTime("19/09/1979"),
                Imagen = "https://s1.latercera.com/wp-content/uploads/2018/07/Thinking_Face_Emoji.jpg"

                },
                    new Empleado
                {
                 Id = 5,
                Nombre = "Consuelo",
                Apellido = "Fernandez",
                FechaNacimiento = Convert.ToDateTime("01/01/1922"),
                Imagen = "https://as.com/epik/imagenes/2018/11/05/portada/1541440062_346544_1541440238_noticia_normal.jpg"

                }

            };
        public IActionResult Index(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return View(trabajadores);

            }
            else
            {

            trabajadores = trabajadores.Where(x => x.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

            return View(trabajadores);
            }  
            
            //Ordena los empleados por apellido
            //trabajadores.OrderBy(empleado => empleado.Apellido).ToList()
            //Saca la lista de empleados cuyo nombre contenga la l.
            //trabajadores.Where(x => x.Nombre.Contains("l")).ToList()
            //Saca la lista de empleados donde la primera letra del nombre es C.
            //x => x.Nombre.Substring(0,1).Contains("C"))
            //x => x.Nombre.Substring(0,1)=="C").ToList()
            //Empleado empleado= trabajadores.FirstOrDefault(x => x.Nombre.Substring(0, 1) == "C");
            //return View(trabajadores.Where(x => x.Nombre.Substring(0, 1) == "C" && x.Nombre.Substring(1,1)=="o").OrderBy(empleado => empleado.Apellido).ToList());
        }

        public IActionResult Detalle()  
        {
            Empleado empleado = new Empleado
            {
                Id = 1,
                Nombre = "Noelia",
                Apellido = "Minguez",
                FechaNacimiento = Convert.ToDateTime("18/10/1996"),
                Imagen = "https://imagenes-amor.net/wp-content/uploads/2018/04/oso_panda_kawaii_imagen_amor-800x800.jpg"
            };
            return View(empleado);
        }
    }
}
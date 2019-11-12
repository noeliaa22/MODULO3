using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ejercicio1.Models;

namespace Ejercicio1.Controllers
{
    public class ProductosController : Controller
    {
        public List<Producto> Productos { get; set; }


        public ProductosController()
        {

        this.Productos = new List<Producto>
            {
                new Producto {Id=1,Nombre="Red Velvet Lipstick",Descripcion="Mate 24h", Tipo="Pintalabios",Precio=19.99,FechaCaducidad=Convert.ToDateTime("01/12/2021"), Imagen="https://media6.ppl-media.com/tr:h-750,w-750,c-at_max/static/img/product/119473/maybelline-color-show-lipstick-red-velvet-209_1_display_1442832075_1ae77f41.jpg" },
                new Producto {Id=2,Nombre="Nude Lipstick",Descripcion="Mate aterciopelado", Tipo="Pintalabios",Precio=14.99,FechaCaducidad=Convert.ToDateTime("01/12/2020"), Imagen="https://d2pa5gi5n2e1an.cloudfront.net/global/images/product/beauty/Avon_Perfectly_Matte_Nudes_Lipstick/Avon_Perfectly_Matte_Nudes_Lipstick_L_2.jpg" },
                new Producto {Id=3,Nombre="AquaLiquid Foundation",Descripcion="Aporta hidratación todo el día", Tipo="Base de maquillaje",Precio=35.99,FechaCaducidad=Convert.ToDateTime("01/11/2020"), Imagen="https://kiko-eco-prd-media-hybris.s3.amazonaws.com/sys-master/images/hf3/h03/10486290874398/KM090702037016Aprincipale_900Wx900H" },
                new Producto {Id=4,Nombre="StayMate Foundation",Descripcion="Controla brillos 12h", Tipo="Base de maquillaje",Precio=29.99,FechaCaducidad=Convert.ToDateTime("01/11/2020"), Imagen="https://www.revolutionbeauty.com/dw/image/v2/BCZJ_PRD/on/demandware.static/-/Sites-revbe-master-catalog/default/dw5b48dcaa/images/hi-res/MatteBaseFoundation.jpg?sw=800&sh=800&sm=fit" },
                new Producto {Id=5,Nombre="Black Eyeliner",Descripcion="Eyeliner liquido permanenete", Tipo="Eyeliner",Precio=6.99,FechaCaducidad=Convert.ToDateTime("01/10/2020"), Imagen="https://ntg-catalog.imgix.net/products/6819572XX_Swipe_jetBlack.jpg?w=1200&h=1443&sfrm=jpg&fit=crop" },
                new Producto {Id=6,Nombre="Butterfly Mascara",Descripcion="Mate 24h", Tipo="Mascara de pestañas",Precio=11.99,FechaCaducidad=Convert.ToDateTime("01/08/2020"), Imagen="https://images-na.ssl-images-amazon.com/images/I/71HBlkuSv-L._SX425_.jpg" }
            };
        }
        public IActionResult Index()
        {

            return View(Productos.OrderBy(x => x.Nombre).ToList());
        }

        public IActionResult ProductosPrecio()
        {

            return View(Productos.OrderBy(x => x.Precio).ToList());
        }

        public IActionResult ProductosTipo()
        {
            return View(Productos.OrderBy(x => x.Tipo).ToList());
        }
    }
}
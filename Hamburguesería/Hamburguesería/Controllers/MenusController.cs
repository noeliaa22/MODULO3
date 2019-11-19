using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hamburguesería.Models;
using Hamburguesería.Models.ViewModels;

namespace Hamburguesería.Controllers
{
    public class MenusController : Controller
    {
        private readonly HamburgueseríaContext _context;

        public MenusController(HamburgueseríaContext context)
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            CrearMenuVM cmvm = new CrearMenuVM
            {
                Principales = await _context.Principales.ToListAsync(),
                Entrantes = await _context.Entrantes.ToListAsync(),
                Postres = await _context.Postres.ToListAsync(),
            };
            return View(cmvm);
        }
        [HttpPost]
        public async Task<IActionResult> NewMenu(CrearMenuVM crearMenuVM)
        {
            Entrante primero = await _context.Entrantes.FindAsync(crearMenuVM.Menu.EntranteId);
            Principal segundo = await _context.Principales.FindAsync(crearMenuVM.Menu.PrincipalId);
            Postre tercero = await _context.Postres.FindAsync(crearMenuVM.Menu.PostreId);
            Menu nuevoMenu = new Menu
            {
                Entrante= primero,
                Principal=segundo,
                Postre=tercero,
                Fecha = DateTime.Now,
                //PrecioTotal = primero.Precio + segundo.Precio + tercero.Precio,
            };

            double precio = 0;
            if (primero!=null)
            {
                precio += primero.Precio;
            }
            if (segundo != null)
            {
                precio += segundo.Precio;
            }
            if (tercero != null)
            {
                precio += tercero.Precio;
            }
            nuevoMenu.PrecioTotal = precio;

            return View(nuevoMenu);

        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarMenu(Menu menu)
        {
            await _context.AddAsync(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,PrecioTotal")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,PrecioTotal")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}

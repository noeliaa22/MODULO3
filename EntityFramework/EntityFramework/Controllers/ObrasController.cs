using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EntityFramework.Controllers
{
    [Authorize] //Si no l indicas nada solo mira si es usuario está logeado
    public class ObrasController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;

        public ObrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            var applicationDbContext = _context.Obras.Include(o => o.Autor).Include(x => x.ObraCategorias).ThenInclude(x => x.Categoria);
            return View(await applicationDbContext.ToListAsync());
            //}
            //return NotFound();
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (_signInManager.IsSignedIn(User))
            //{

            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);

            //}
            //return NotFound();
        }

        // GET: Obras/Create
        [Authorize(Roles = "PremiumUser, Admin")]
        public async Task<IActionResult> Create()
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    IdentityUser user = await _userManager.GetUserAsync(User);
            //    if (await _userManager.IsInRoleAsync(user, "PremiumUser") || await _userManager.IsInRoleAsync(user, "Admin"))
            //    {

            CrearObraVM covm = new CrearObraVM
            {
                Autores = await _context.Autores.ToListAsync(),
            };
            return View(covm);

            //    }
            //}
            //return NotFound();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearObraVM covm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covm.Obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Id", covm.Obra.AutorId);
            return View(covm);
        }

        // GET: Obras/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    IdentityUser user = await _userManager.GetUserAsync(User);
            //    if (await _userManager.IsInRoleAsync(user, "Admin"))
            //    {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Id", obra.AutorId);
            return View(obra);
            //    }
            //}
            //return NotFound();
        }


        // POST: Obras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AnioPublicacion,AutorId")] Obra obra)
        {
            if (id != obra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Id", obra.AutorId);
            return View(obra);
        }

        // GET: Obras/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    IdentityUser user = await _userManager.GetUserAsync(User);
            //    if (await _userManager.IsInRoleAsync(user, "Admin"))
            //    {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
            //    }
            //}
            //return NotFound();
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id)
        {
            return _context.Obras.Any(e => e.Id == id);
        }
    }
}

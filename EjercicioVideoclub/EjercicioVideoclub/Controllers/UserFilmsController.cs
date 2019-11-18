using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjercicioVideoclub.Models;

namespace EjercicioVideoclub.Controllers
{
    public class UserFilmsController : Controller
    {
        private readonly VideoclubContext _context;

        public UserFilmsController(VideoclubContext context)
        {
            _context = context;
        }

        // GET: UserFilms
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsersFilms.Include(x=>x.Film).Include(x=>x.User).ToListAsync());
        }

        // GET: UserFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UsersFilms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }
        public async Task<IActionResult> ConfirmarAlquiler(int id)
        {
            Film film = await _context.Films.FindAsync(id);
            User user = await _context.Users.FindAsync(1);
            UserFilm alquiler = new UserFilm
            {
                Film = film,
                User = user,
                DataRental = DateTime.Now,
            };

            _context.Add(alquiler); //añadir el nuevo registro de alquiler
            film.Rented = "Ocupada";
            _context.Update(film); //Actualizar la base de datos de la película
            await _context.SaveChangesAsync(); //Guardar los cambios en la BBDD

            //Redirigir a los datos del usuario Mis Alquileres
            return RedirectToAction("Index", "Users"); 
            //Primero se pone el método al que lo quieres redirigir y luego el controlador

        }

        public async Task<IActionResult> Devolver(int id)
        {
            UserFilm alquiler = await _context.UsersFilms.Include(x=>x.Film).FirstOrDefaultAsync(x=>x.Id==id);
            return View(alquiler);
        }
        public async Task<IActionResult> ConfirmarDevolucion(int id)
        {
            UserFilm alquiler = await _context.UsersFilms.Include(x => x.Film).FirstOrDefaultAsync(x => x.Id == id);
            alquiler.ReturnDate = DateTime.Now;
            Film film = alquiler.Film; //La pelicula vinculada a alquiler
            film.Rented = "Disponible";
            _context.Update(alquiler);
            _context.Update(film);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Films");
        }

        // GET: UserFilms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataRental,ReturnDate")] UserFilm userFilm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFilm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userFilm);
        }

        // GET: UserFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UsersFilms.FindAsync(id);
            if (userFilm == null)
            {
                return NotFound();
            }
            return View(userFilm);
        }

        // POST: UserFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataRental,ReturnDate")] UserFilm userFilm)
        {
            if (id != userFilm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFilm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFilmExists(userFilm.Id))
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
            return View(userFilm);
        }

        // GET: UserFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UsersFilms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

        // POST: UserFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFilm = await _context.UsersFilms.FindAsync(id);
            _context.UsersFilms.Remove(userFilm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFilmExists(int id)
        {
            return _context.UsersFilms.Any(e => e.Id == id);
        }
    }
}

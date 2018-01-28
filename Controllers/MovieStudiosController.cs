using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using Projekt.Data;
using Microsoft.AspNetCore.Authorization;

namespace Projekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieStudiosController : Controller
    {
        private readonly MovieContext _context;

        public MovieStudiosController(MovieContext context)
        {
            _context = context;
        }

        // GET: MovieStudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieStudio.ToListAsync());
        }

        // GET: MovieStudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieStudio = await _context.MovieStudio
                .SingleOrDefaultAsync(m => m.MovieStudioID == id);
            if (movieStudio == null)
            {
                return NotFound();
            }

            return View(movieStudio);
        }

        // GET: MovieStudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieStudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieStudioID,Name,Founded")] MovieStudio movieStudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieStudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieStudio);
        }

        // GET: MovieStudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieStudio = await _context.MovieStudio.SingleOrDefaultAsync(m => m.MovieStudioID == id);
            if (movieStudio == null)
            {
                return NotFound();
            }
            return View(movieStudio);
        }

        // POST: MovieStudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieStudioID,Name,Founded")] MovieStudio movieStudio)
        {
            if (id != movieStudio.MovieStudioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieStudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieStudioExists(movieStudio.MovieStudioID))
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
            return View(movieStudio);
        }

        // GET: MovieStudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieStudio = await _context.MovieStudio
                .SingleOrDefaultAsync(m => m.MovieStudioID == id);
            if (movieStudio == null)
            {
                return NotFound();
            }

            return View(movieStudio);
        }

        // POST: MovieStudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieStudio = await _context.MovieStudio.SingleOrDefaultAsync(m => m.MovieStudioID == id);
            _context.MovieStudio.Remove(movieStudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieStudioExists(int id)
        {
            return _context.MovieStudio.Any(e => e.MovieStudioID == id);
        }
    }
}

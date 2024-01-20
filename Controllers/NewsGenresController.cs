using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBBNews.Data;
using GBBNews.Models;

namespace GBBNews.Controllers
{
    public class NewsGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsGenres
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsGenres.ToListAsync());
        }

        // GET: NewsGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsGenre = await _context.NewsGenres
                .FirstOrDefaultAsync(m => m.NewsGenreId == id);
            if (newsGenre == null)
            {
                return NotFound();
            }

            return View(newsGenre);
        }

        // GET: NewsGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsGenreId,Genre,genrepicture")] NewsGenre newsGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsGenre);
        }

        // GET: NewsGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsGenre = await _context.NewsGenres.FindAsync(id);
            if (newsGenre == null)
            {
                return NotFound();
            }
            return View(newsGenre);
        }

        // POST: NewsGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsGenreId,Genre,genrepicture")] NewsGenre newsGenre)
        {
            if (id != newsGenre.NewsGenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsGenreExists(newsGenre.NewsGenreId))
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
            return View(newsGenre);
        }

        // GET: NewsGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsGenre = await _context.NewsGenres
                .FirstOrDefaultAsync(m => m.NewsGenreId == id);
            if (newsGenre == null)
            {
                return NotFound();
            }

            return View(newsGenre);
        }

        // POST: NewsGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsGenre = await _context.NewsGenres.FindAsync(id);
            if (newsGenre != null)
            {
                _context.NewsGenres.Remove(newsGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsGenreExists(int id)
        {
            return _context.NewsGenres.Any(e => e.NewsGenreId == id);
        }
    }
}

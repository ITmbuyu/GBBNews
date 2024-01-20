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
    public class NewsStaffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsStaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsStaffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsStaffs.ToListAsync());
        }

        // GET: NewsStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsStaff = await _context.NewsStaffs
                .FirstOrDefaultAsync(m => m.NewsStaffId == id);
            if (newsStaff == null)
            {
                return NotFound();
            }

            return View(newsStaff);
        }

        // GET: NewsStaffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsStaffId,NewsStaffName,NewsStaffSurname,staffBio,staffpicture")] NewsStaff newsStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsStaff);
        }

        // GET: NewsStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsStaff = await _context.NewsStaffs.FindAsync(id);
            if (newsStaff == null)
            {
                return NotFound();
            }
            return View(newsStaff);
        }

        // POST: NewsStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsStaffId,NewsStaffName,NewsStaffSurname,staffBio,staffpicture")] NewsStaff newsStaff)
        {
            if (id != newsStaff.NewsStaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsStaffExists(newsStaff.NewsStaffId))
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
            return View(newsStaff);
        }

        // GET: NewsStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsStaff = await _context.NewsStaffs
                .FirstOrDefaultAsync(m => m.NewsStaffId == id);
            if (newsStaff == null)
            {
                return NotFound();
            }

            return View(newsStaff);
        }

        // POST: NewsStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsStaff = await _context.NewsStaffs.FindAsync(id);
            if (newsStaff != null)
            {
                _context.NewsStaffs.Remove(newsStaff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsStaffExists(int id)
        {
            return _context.NewsStaffs.Any(e => e.NewsStaffId == id);
        }
    }
}

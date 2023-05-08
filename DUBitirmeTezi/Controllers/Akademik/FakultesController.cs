using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models.Akademik;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers.Akademik
{
    [Authorize]
    public class FakultesController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public FakultesController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fakultes.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulte = await _context.Fakultes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fakulte == null)
            {
                return NotFound();
            }

            return View(fakulte);
        }

        // GET: Fakultes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fakultes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FacultyName")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fakulte);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            return View(fakulte);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulte = await _context.Fakultes.FindAsync(id);
            if (fakulte == null)
            {
                return NotFound();
            }
            return View(fakulte);
        }

        // POST: Fakultes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FacultyName")] Fakulte fakulte)
        {
            if (id != fakulte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakulte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakulteExists(fakulte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AdminPanel");
            }
            return View(fakulte);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulte = await _context.Fakultes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fakulte == null)
            {
                return NotFound();
            }

            return View(fakulte);
        }

        // POST: Fakultes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fakulte = await _context.Fakultes.FindAsync(id);
            _context.Fakultes.Remove(fakulte);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool FakulteExists(int id)
        {
            return _context.Fakultes.Any(e => e.Id == id);
        }
    }
}

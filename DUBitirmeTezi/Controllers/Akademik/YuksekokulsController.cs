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
    public class YuksekokulsController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public YuksekokulsController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: Yuksekokuls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yuksekokuls.ToListAsync());
        }

        // GET: Yuksekokuls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yuksekokul = await _context.Yuksekokuls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yuksekokul == null)
            {
                return NotFound();
            }

            return View(yuksekokul);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yuksekokuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CollageName")] Yuksekokul yuksekokul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yuksekokul);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(yuksekokul);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yuksekokul = await _context.Yuksekokuls.FindAsync(id);
            if (yuksekokul == null)
            {
                return NotFound();
            }
            return View(yuksekokul);
        }

        // POST: Yuksekokuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CollageName")] Yuksekokul yuksekokul)
        {
            if (id != yuksekokul.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yuksekokul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YuksekokulExists(yuksekokul.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(yuksekokul);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yuksekokul = await _context.Yuksekokuls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yuksekokul == null)
            {
                return NotFound();
            }

            return View(yuksekokul);
        }

        // POST: Yuksekokuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yuksekokul = await _context.Yuksekokuls.FindAsync(id);
            _context.Yuksekokuls.Remove(yuksekokul);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool YuksekokulExists(int id)
        {
            return _context.Yuksekokuls.Any(e => e.Id == id);
        }
    }
}

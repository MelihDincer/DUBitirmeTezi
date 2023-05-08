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
    public class YuksekokulDetaysController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public YuksekokulDetaysController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> YuksekokulDetay(int id)
        {
            var dUBitirmeTeziDbContext = _context.YuksekokulDetays
                .Include(y => y.Yuksekokul)
                .Where(x => x.Id == id)
                ;
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            var dUBitirmeTeziDbContext = _context.YuksekokulDetays.Include(y => y.Yuksekokul);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: YuksekokulDetays
        public async Task<IActionResult> Index()
        {
            var dUBitirmeTeziDbContext = _context.YuksekokulDetays.Include(y => y.Yuksekokul);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: YuksekokulDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yuksekokulDetay = await _context.YuksekokulDetays
                .Include(y => y.Yuksekokul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yuksekokulDetay == null)
            {
                return NotFound();
            }

            return View(yuksekokulDetay);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["YuksekokulId"] = new SelectList(_context.Yuksekokuls, "Id", "CollageName");
            return View();
        }

        // POST: YuksekokulDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YuksekokulId,Description1,Description2")] YuksekokulDetay yuksekokulDetay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yuksekokulDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            ViewData["YuksekokulId"] = new SelectList(_context.Yuksekokuls, "Id", "CollageName", yuksekokulDetay.YuksekokulId);
            return View(yuksekokulDetay);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yuksekokulDetay = await _context.YuksekokulDetays.FindAsync(id);
            if (yuksekokulDetay == null)
            {
                return NotFound();
            }
            ViewData["YuksekokulId"] = new SelectList(_context.Yuksekokuls, "Id", "CollageName", yuksekokulDetay.YuksekokulId);
            return View(yuksekokulDetay);
        }

        // POST: YuksekokulDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YuksekokulId,Description1,Description2")] YuksekokulDetay yuksekokulDetay)
        {
            if (id != yuksekokulDetay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yuksekokulDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YuksekokulDetayExists(yuksekokulDetay.Id))
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
            ViewData["YuksekokulId"] = new SelectList(_context.Yuksekokuls, "Id", "CollageName", yuksekokulDetay.YuksekokulId);
            return View(yuksekokulDetay);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yuksekokulDetay = await _context.YuksekokulDetays
                .Include(y => y.Yuksekokul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yuksekokulDetay == null)
            {
                return NotFound();
            }

            return View(yuksekokulDetay);
        }

        // POST: YuksekokulDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yuksekokulDetay = await _context.YuksekokulDetays.FindAsync(id);
            _context.YuksekokulDetays.Remove(yuksekokulDetay);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool YuksekokulDetayExists(int id)
        {
            return _context.YuksekokulDetays.Any(e => e.Id == id);
        }
    }
}

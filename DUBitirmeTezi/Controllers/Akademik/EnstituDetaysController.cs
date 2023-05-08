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
    public class EnstituDetaysController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public EnstituDetaysController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> EnstituDetay(int id)
        {
            var dUBitirmeTeziDbContext = _context.EnstituDetays
                .Include(e => e.Enstitu)
                .Where(x => x.Id == id)
                ;
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            var dUBitirmeTeziDbContext = _context.EnstituDetays.Include(e => e.Enstitu);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: EnstituDetays
        public async Task<IActionResult> Index()
        {
            var dUBitirmeTeziDbContext = _context.EnstituDetays.Include(e => e.Enstitu);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: EnstituDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstituDetay = await _context.EnstituDetays
                .Include(e => e.Enstitu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enstituDetay == null)
            {
                return NotFound();
            }

            return View(enstituDetay);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["EnstituId"] = new SelectList(_context.Enstitus, "Id", "EnstituName");
            return View();
        }

        // POST: EnstituDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnstituId,Description,Description2")] EnstituDetay enstituDetay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enstituDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            ViewData["EnstituId"] = new SelectList(_context.Enstitus, "Id", "EnstituName", enstituDetay.EnstituId);
            return View(enstituDetay);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstituDetay = await _context.EnstituDetays.FindAsync(id);
            if (enstituDetay == null)
            {
                return NotFound();
            }
            ViewData["EnstituId"] = new SelectList(_context.Enstitus, "Id", "EnstituName", enstituDetay.EnstituId);
            return View(enstituDetay);
        }

        // POST: EnstituDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnstituId,Description,Description2")] EnstituDetay enstituDetay)
        {
            if (id != enstituDetay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enstituDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnstituDetayExists(enstituDetay.Id))
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
            ViewData["EnstituId"] = new SelectList(_context.Enstitus, "Id", "EnstituName", enstituDetay.EnstituId);
            return View(enstituDetay);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstituDetay = await _context.EnstituDetays
                .Include(e => e.Enstitu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enstituDetay == null)
            {
                return NotFound();
            }

            return View(enstituDetay);
        }

        // POST: EnstituDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enstituDetay = await _context.EnstituDetays.FindAsync(id);
            _context.EnstituDetays.Remove(enstituDetay);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool EnstituDetayExists(int id)
        {
            return _context.EnstituDetays.Any(e => e.Id == id);
        }
    }
}

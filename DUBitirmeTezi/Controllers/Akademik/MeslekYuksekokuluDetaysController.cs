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
    public class MeslekYuksekokuluDetaysController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public MeslekYuksekokuluDetaysController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MeslekYuksekokulDetay(int id)
        {
            var dUBitirmeTeziDbContext = _context.MeslekYuksekokulDetays
                .Include(m => m.MeslekYuksekokulu)
                .Where(x => x.Id == id)
                ;
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            var dUBitirmeTeziDbContext = _context.MeslekYuksekokulDetays.Include(m => m.MeslekYuksekokulu);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: MeslekYuksekokuluDetays
        public async Task<IActionResult> Index()
        {
            var dUBitirmeTeziDbContext = _context.MeslekYuksekokulDetays.Include(m => m.MeslekYuksekokulu);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: MeslekYuksekokuluDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meslekYuksekokulDetay = await _context.MeslekYuksekokulDetays
                .Include(m => m.MeslekYuksekokulu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meslekYuksekokulDetay == null)
            {
                return NotFound();
            }

            return View(meslekYuksekokulDetay);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["MeslekYuksekokuluId"] = new SelectList(_context.MeslekYuksekokulus, "Id", "TechnicalSchoolName");
            return View();
        }

        // POST: MeslekYuksekokuluDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeslekYuksekokuluId,Description1,Description2")] MeslekYuksekokulDetay meslekYuksekokulDetay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meslekYuksekokulDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            ViewData["MeslekYuksekokuluId"] = new SelectList(_context.MeslekYuksekokulus, "Id", "TechnicalSchoolName", meslekYuksekokulDetay.MeslekYuksekokuluId);
            return View(meslekYuksekokulDetay);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meslekYuksekokulDetay = await _context.MeslekYuksekokulDetays.FindAsync(id);
            if (meslekYuksekokulDetay == null)
            {
                return NotFound();
            }
            ViewData["MeslekYuksekokuluId"] = new SelectList(_context.MeslekYuksekokulus, "Id", "TechnicalSchoolName", meslekYuksekokulDetay.MeslekYuksekokuluId);
            return View(meslekYuksekokulDetay);
        }

        // POST: MeslekYuksekokuluDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeslekYuksekokuluId,Description1,Description2")] MeslekYuksekokulDetay meslekYuksekokulDetay)
        {
            if (id != meslekYuksekokulDetay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meslekYuksekokulDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeslekYuksekokulDetayExists(meslekYuksekokulDetay.Id))
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
            ViewData["MeslekYuksekokuluId"] = new SelectList(_context.MeslekYuksekokulus, "Id", "TechnicalSchoolName", meslekYuksekokulDetay.MeslekYuksekokuluId);
            return View(meslekYuksekokulDetay);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meslekYuksekokulDetay = await _context.MeslekYuksekokulDetays
                .Include(m => m.MeslekYuksekokulu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meslekYuksekokulDetay == null)
            {
                return NotFound();
            }

            return View(meslekYuksekokulDetay);
        }

        // POST: MeslekYuksekokuluDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meslekYuksekokulDetay = await _context.MeslekYuksekokulDetays.FindAsync(id);
            _context.MeslekYuksekokulDetays.Remove(meslekYuksekokulDetay);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool MeslekYuksekokulDetayExists(int id)
        {
            return _context.MeslekYuksekokulDetays.Any(e => e.Id == id);
        }
    }
}

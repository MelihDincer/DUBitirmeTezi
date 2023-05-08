using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models.Universitemiz;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers.Universitemiz
{
    [Authorize]
    public class YonetimsController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public YonetimsController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: Yonetims
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yonetims.ToListAsync());
        }

        // GET: Yonetims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetim == null)
            {
                return NotFound();
            }

            return View(yonetim);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Unvan")] Yonetim yonetim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetim);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(yonetim);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims.FindAsync(id);
            if (yonetim == null)
            {
                return NotFound();
            }
            return View(yonetim);
        }

        // POST: Yonetims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Unvan")] Yonetim yonetim)
        {
            if (id != yonetim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetimExists(yonetim.Id))
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
            return View(yonetim);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetim == null)
            {
                return NotFound();
            }

            return View(yonetim);
        }

        // POST: Yonetims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetim = await _context.Yonetims.FindAsync(id);
            _context.Yonetims.Remove(yonetim);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool YonetimExists(int id)
        {
            return _context.Yonetims.Any(e => e.Id == id);
        }
    }
}

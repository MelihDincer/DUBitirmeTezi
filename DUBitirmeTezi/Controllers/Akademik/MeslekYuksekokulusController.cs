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
    public class MeslekYuksekokulusController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public MeslekYuksekokulusController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: MeslekYuksekokulus
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeslekYuksekokulus.ToListAsync());
        }

        // GET: MeslekYuksekokulus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meslekYuksekokulu = await _context.MeslekYuksekokulus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meslekYuksekokulu == null)
            {
                return NotFound();
            }

            return View(meslekYuksekokulu);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeslekYuksekokulus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TechnicalSchoolName")] MeslekYuksekokulu meslekYuksekokulu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meslekYuksekokulu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meslekYuksekokulu);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meslekYuksekokulu = await _context.MeslekYuksekokulus.FindAsync(id);
            if (meslekYuksekokulu == null)
            {
                return NotFound();
            }
            return View(meslekYuksekokulu);
        }

        // POST: MeslekYuksekokulus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TechnicalSchoolName")] MeslekYuksekokulu meslekYuksekokulu)
        {
            if (id != meslekYuksekokulu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meslekYuksekokulu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeslekYuksekokuluExists(meslekYuksekokulu.Id))
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
            return View(meslekYuksekokulu);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meslekYuksekokulu = await _context.MeslekYuksekokulus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meslekYuksekokulu == null)
            {
                return NotFound();
            }

            return View(meslekYuksekokulu);
        }

        // POST: MeslekYuksekokulus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meslekYuksekokulu = await _context.MeslekYuksekokulus.FindAsync(id);
            _context.MeslekYuksekokulus.Remove(meslekYuksekokulu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MeslekYuksekokuluExists(int id)
        {
            return _context.MeslekYuksekokulus.Any(e => e.Id == id);
        }
    }
}

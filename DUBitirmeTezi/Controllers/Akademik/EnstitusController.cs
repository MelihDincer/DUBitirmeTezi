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
    public class EnstitusController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public EnstitusController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: Enstitus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enstitus.ToListAsync());
        }

        // GET: Enstitus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstitu = await _context.Enstitus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enstitu == null)
            {
                return NotFound();
            }

            return View(enstitu);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enstitus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnstituName")] Enstitu enstitu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enstitu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(enstitu);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstitu = await _context.Enstitus.FindAsync(id);
            if (enstitu == null)
            {
                return NotFound();
            }
            return View(enstitu);
        }

        // POST: Enstitus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnstituName")] Enstitu enstitu)
        {
            if (id != enstitu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enstitu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnstituExists(enstitu.Id))
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
            return View(enstitu);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstitu = await _context.Enstitus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enstitu == null)
            {
                return NotFound();
            }

            return View(enstitu);
        }

        // POST: Enstitus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enstitu = await _context.Enstitus.FindAsync(id);
            _context.Enstitus.Remove(enstitu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EnstituExists(int id)
        {
            return _context.Enstitus.Any(e => e.Id == id);
        }
    }
}

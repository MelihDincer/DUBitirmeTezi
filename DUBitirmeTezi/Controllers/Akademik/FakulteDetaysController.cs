using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models.Akademik;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers.Akademik
{
    public class FakulteDetaysController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly DUBitirmeTeziDbContext _context;

        public FakulteDetaysController(DUBitirmeTeziDbContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        public async Task<IActionResult> BolumDetay(int id)
        {
            var dUBitirmeTeziDbContext = _context.FakulteDetays
                .Include(f => f.Fakulte)
                .Where(x => x.Id == id)
                ;
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        public async Task<IActionResult> Bolumler(int id)
        {
            var dUBitirmeTeziDbContext = _context.FakulteDetays
                .Include(f => f.Fakulte)
                .Where(x=> x.FakulteId == id)
                ;
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            var dUBitirmeTeziDbContext = _context.FakulteDetays.Include(f => f.Fakulte);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: FakulteDetays
        public async Task<IActionResult> Index()
        {
            var dUBitirmeTeziDbContext = _context.FakulteDetays.Include(f => f.Fakulte);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: FakulteDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulteDetay = await _context.FakulteDetays
                .Include(f => f.Fakulte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fakulteDetay == null)
            {
                return NotFound();
            }

            return View(fakulteDetay);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["FakulteId"] = new SelectList(_context.Fakultes, "Id", "FacultyName");
            return View();
        }

        // POST: FakulteDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FakulteId,EducationName,Description,Description2,Mission,Vision")] FakulteDetay fakulteDetay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fakulteDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            ViewData["FakulteId"] = new SelectList(_context.Fakultes, "Id", "FacultyName", fakulteDetay.FakulteId);
            return View(fakulteDetay);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulteDetay = await _context.FakulteDetays.FindAsync(id);
            if (fakulteDetay == null)
            {
                return NotFound();
            }
            ViewData["FakulteId"] = new SelectList(_context.Fakultes, "Id", "FacultyName", fakulteDetay.FakulteId);
            return View(fakulteDetay);
        }

        // POST: FakulteDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FakulteId,EducationName,Description,Description2,Mission,Vision")] FakulteDetay fakulteDetay)
        {
            if (id != fakulteDetay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakulteDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakulteDetayExists(fakulteDetay.Id))
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
            ViewData["FakulteId"] = new SelectList(_context.Fakultes, "Id", "FacultyName", fakulteDetay.FakulteId);
            return View(fakulteDetay);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulteDetay = await _context.FakulteDetays
                .Include(f => f.Fakulte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fakulteDetay == null)
            {
                return NotFound();
            }

            return View(fakulteDetay);
        }

        // POST: FakulteDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fakulteDetay = await _context.FakulteDetays.FindAsync(id);
            _context.FakulteDetays.Remove(fakulteDetay);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool FakulteDetayExists(int id)
        {
            return _context.FakulteDetays.Any(e => e.Id == id);
        }
    }
}

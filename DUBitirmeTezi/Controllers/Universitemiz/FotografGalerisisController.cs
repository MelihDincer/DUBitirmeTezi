using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models.Universitemiz;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers.Universitemiz
{
    public class FotografGalerisisController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;
        private readonly IHostingEnvironment _environment;


        public FotografGalerisisController(DUBitirmeTeziDbContext context, 
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            return View(await _context.FotografGalerisis.ToListAsync());
        }

        // GET: FotografGalerisis
        public async Task<IActionResult> Index()
        {
            return View(await _context.FotografGalerisis.ToListAsync());
        }

        // GET: FotografGalerisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografGalerisi = await _context.FotografGalerisis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografGalerisi == null)
            {
                return NotFound();
            }

            return View(fotografGalerisi);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FotografGalerisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image")] FotografGalerisi fotografGalerisi, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "FotoGalerisi", Image.FileName);
                    var filePath = Path.Combine(uploads);
                    var indexPath = Path.Combine("FotoGalerisi/", Image.FileName);
                    fotografGalerisi.Url = indexPath;
                    if (Image.Length > 0)
                    {
                        Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        fotografGalerisi.Image = filePath;
                        _context.Add(fotografGalerisi);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("AdminPanel");
                }
            }
            return View(fotografGalerisi);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografGalerisi = await _context.FotografGalerisis.FindAsync(id);
            if (fotografGalerisi == null)
            {
                return NotFound();
            }
            return View(fotografGalerisi);
        }

        // POST: FotografGalerisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image")] FotografGalerisi fotografGalerisi, IFormFile Image)
        {
            if (id != fotografGalerisi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        var uploads = Path.Combine(_environment.WebRootPath, "FotoGalerisi", Image.FileName);
                        var filePath = Path.Combine(uploads);
                        var indexPath = Path.Combine("FotoGalerisi/", Image.FileName);
                        fotografGalerisi.Url = indexPath;
                        if (Image.Length > 0)
                        {
                            Image.CopyTo(new FileStream(filePath, FileMode.Create));
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            fotografGalerisi.Image = filePath;
                            _context.Add(fotografGalerisi);
                            await _context.SaveChangesAsync();
                        }
                        return RedirectToAction("AdminPanel");
                    }
                    _context.Update(fotografGalerisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografGalerisiExists(fotografGalerisi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AdminPanel", "FotografGalerisis");
            }
            return View(fotografGalerisi);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografGalerisi = await _context.FotografGalerisis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografGalerisi == null)
            {
                return NotFound();
            }

            return View(fotografGalerisi);
        }

        // POST: FotografGalerisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotografGalerisi = await _context.FotografGalerisis.FindAsync(id);
            _context.FotografGalerisis.Remove(fotografGalerisi);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool FotografGalerisiExists(int id)
        {
            return _context.FotografGalerisis.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models.Universitemiz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers.Universitemiz
{
    public class YonetimDetaysController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;
        private readonly IHostingEnvironment _environment;

        public YonetimDetaysController(DUBitirmeTeziDbContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        public async Task<IActionResult> UnvanDetay(int id)
        {
            var dUBitirmeTeziDbContext = _context.YonetimDetays
                .Include(y => y.YonetimTable)
                .Where(x => x.Id == id)
                ;
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            var dUBitirmeTeziDbContext = _context.YonetimDetays.Include(y => y.YonetimTable);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: YonetimDetays
        public async Task<IActionResult> Index()
        {
            var dUBitirmeTeziDbContext = _context.YonetimDetays.Include(y => y.YonetimTable);
            return View(await dUBitirmeTeziDbContext.ToListAsync());
        }

        // GET: YonetimDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetimDetay = await _context.YonetimDetays
                .Include(y => y.YonetimTable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetimDetay == null)
            {
                return NotFound();
            }

            return View(yonetimDetay);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["YonetimId"] = new SelectList(_context.Yonetims, "Id", "Unvan");
            return View();
        }

        // POST: YonetimDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YonetimId,Name,Description,Image")] YonetimDetay yonetimDetay, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "Yonetim", Image.FileName);
                    var filePath = Path.Combine(uploads);

                    var indexPath = Path.Combine("Yonetim/", Image.FileName);
                    yonetimDetay.Url = "/Yonetim/" + Image.FileName;

                    if (Image.Length > 0)
                    {
                        Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        yonetimDetay.Image = filePath;
                        _context.Add(yonetimDetay);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("AdminPanel");
                }
            }

            ViewData["YonetimId"] = new SelectList(_context.Yonetims, "Id", "Unvan", yonetimDetay.YonetimId);
            return View(yonetimDetay);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetimDetay = await _context.YonetimDetays.FindAsync(id);
            if (yonetimDetay == null)
            {
                return NotFound();
            }
            ViewData["YonetimId"] = new SelectList(_context.Yonetims, "Id", "Unvan", yonetimDetay.YonetimId);
            return View(yonetimDetay);
        }

        // POST: YonetimDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YonetimId,Name,Description,Image")] YonetimDetay yonetimDetay, IFormFile Image)
        {
            if (id != yonetimDetay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        var uploads = Path.Combine(_environment.WebRootPath, "Yonetim", Image.FileName);
                        var filePath = Path.Combine(uploads);

                        var indexPath = Path.Combine("Yonetim/", Image.FileName);
                        yonetimDetay.Url = "/Yonetim/" + Image.FileName;

                        if (Image.Length > 0)
                        {
                            Image.CopyTo(new FileStream(filePath, FileMode.Create));
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            yonetimDetay.Image = filePath;
                            _context.Update(yonetimDetay);
                            await _context.SaveChangesAsync();
                        }
                    }
                    _context.Update(yonetimDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetimDetayExists(yonetimDetay.Id))
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
            ViewData["YonetimId"] = new SelectList(_context.Yonetims, "Id", "Unvan", yonetimDetay.YonetimId);
            return View(yonetimDetay);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetimDetay = await _context.YonetimDetays
                .Include(y => y.YonetimTable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetimDetay == null)
            {
                return NotFound();
            }

            return View(yonetimDetay);
        }

        // POST: YonetimDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetimDetay = await _context.YonetimDetays.FindAsync(id);
            _context.YonetimDetays.Remove(yonetimDetay);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        private bool YonetimDetayExists(int id)
        {
            return _context.YonetimDetays.Any(e => e.Id == id);
        }
    }
}

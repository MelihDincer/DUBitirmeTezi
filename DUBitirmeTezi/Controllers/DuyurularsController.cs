using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers
{
    public class DuyurularsController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;
        private readonly IHostingEnvironment _environment;


        public DuyurularsController(DUBitirmeTeziDbContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Authorize]
        public async Task<IActionResult> AdminPanel()
        {
            var list = await _context.Duyurulars.ToListAsync();
            return View(list);
        }

        // GET: Duyurulars
        public async Task<IActionResult> Index()
        {
            var list = await _context.Duyurulars
                .Where(x=>x.AktifMi == true).Select(x=> new Duyurular()
                {
                    Id = x.Id,
                    Aciklama1 = x.Aciklama1,
                    Aciklama2 = x.Aciklama2,
                    AktifMi = x.AktifMi,
                    //duyuru adı 50 den fazla karakter içeriyorsa sadece ilk 50 karakterini göster
                    DuyuruAdi = x.DuyuruAdi.Length>50 ? x.DuyuruAdi.Substring(0,50) + "..." : x.DuyuruAdi,
                    EklendigiTarih = x.EklendigiTarih,
                    Image = x.Image,
                    Url = x.Url
                })
                .ToListAsync();
            return View(list);
        }

        // GET: Duyurulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyurular = await _context.Duyurulars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyurular == null)
            {
                return NotFound();
            }

            return View(duyurular);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duyurulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DuyuruAdi,Aciklama1,Aciklama2,AktifMi,Image")] Duyurular duyurular, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if(Image != null)
                {
                    duyurular.EklendigiTarih = DateTime.Today;
                    var uploads = Path.Combine(_environment.WebRootPath, "Duyurular", Image.FileName);
                    var filePath = Path.Combine(uploads);
                    var indexPath = Path.Combine("Duyurular/", Image.FileName);
                    duyurular.Url = "/Duyurular/" + Image.FileName;

                    if (Image.Length > 0)
                    {
                        Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        duyurular.Image = filePath;
                        _context.Add(duyurular);
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction("AdminPanel", "Duyurulars");
                }
            }
            return View(duyurular);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyurular = await _context.Duyurulars.FindAsync(id);
            if (duyurular == null)
            {
                return NotFound();
            }
            return View(duyurular);
        }

        // POST: Duyurulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DuyuruAdi,Aciklama1,Aciklama2,Image")] Duyurular duyurular, IFormFile Image)
        {
            if (id != duyurular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        duyurular.EklendigiTarih = DateTime.Today;
                        var uploads = Path.Combine(_environment.WebRootPath, "Duyurular", Image.FileName);
                        var filePath = Path.Combine(uploads);

                        var indexPath = Path.Combine("Duyurular/", Image.FileName);
                        duyurular.Url = "/Duyurular/" + Image.FileName;

                        if (Image.Length > 0)
                        {
                            Image.CopyTo(new FileStream(filePath, FileMode.Create));
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            duyurular.Image = filePath;
                            _context.Update(duyurular);
                            await _context.SaveChangesAsync();
                        }
                    }
                    _context.Update(duyurular);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuyurularExists(duyurular.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AdminPanel", "Duyurulars");
            }
            return View(duyurular);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyurular = await _context.Duyurulars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyurular == null)
            {
                return NotFound();
            }

            return View(duyurular);
        }

        // POST: Duyurulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duyurular = await _context.Duyurulars.FindAsync(id);
            _context.Duyurulars.Remove(duyurular);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel","Duyurulars");
        }

        private bool DuyurularExists(int id)
        {
            return _context.Duyurulars.Any(e => e.Id == id);
        }
    }
}

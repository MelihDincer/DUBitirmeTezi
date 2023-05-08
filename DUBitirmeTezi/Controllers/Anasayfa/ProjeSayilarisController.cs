using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models.Anasayfa;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers.Anasayfa
{
    [Authorize]
    public class ProjeSayilarisController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public ProjeSayilarisController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeSayilari = await _context.ProjeSayilaris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeSayilari == null)
            {
                return NotFound();
            }

            return View(projeSayilari);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeSayilari = await _context.ProjeSayilaris.FindAsync(id);
            if (projeSayilari == null)
            {
                return NotFound();
            }
            return View(projeSayilari);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Fakulte,Enstitu,Yuksekokul,MeslekYuksekokulu,LisansProgrami,LisansutsuProgrami,UygulamaArastirmaMerkezi,Koordinatorluk,BapProjesi,Patent,SponsorluProje,TubitakProjesi")] ProjeSayilari projeSayilari)
        {
            if (id != projeSayilari.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeSayilari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjeSayilariExists(projeSayilari.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "ProjeSayilaris", new { id = 1 });
            }
            return View(projeSayilari);
        }

        private bool ProjeSayilariExists(int id)
        {
            return _context.ProjeSayilaris.Any(e => e.Id == id);
        }
    }
}

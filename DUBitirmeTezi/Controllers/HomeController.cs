using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models;
using DUBitirmeTezi.Models.Anasayfa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DUBitirmeTezi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DUBitirmeTeziDbContext _context;


        public HomeController(ILogger<HomeController> logger,
            DUBitirmeTeziDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [Authorize]
        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Index()
        {
            IndexModel model = new IndexModel();
            model.Duyurular = new List<Duyurular>();
            model.ProjeSayilari = new List<ProjeSayilari>();

            var duyurular = _context.Duyurulars
                .Where(x => x.AktifMi == true)
                .Take(3).ToList();
            model.Duyurular = duyurular;

            var veriler = _context.ProjeSayilaris.ToList();
            model.ProjeSayilari = veriler;

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using PXLSchoolManagement.ViewModels;
using System.Diagnostics;

namespace PXLSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Handboeken = _context.Handboeken.ToList(),
                Studenten = _context.Studenten.ToList(),
                Vaklectoren = _context.Vaklectoren.ToList(),
                Inschrijvingen = _context.Inschrijvingen.ToList()
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using PXLSchoolManagement.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace PXLSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
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
    }
}
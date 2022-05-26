using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq;
using PXLSchoolManagement.Areas.Admin.Models;

namespace PXLSchoolManagement.Controllers
{
    [Area("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Gebruiker> _userManager;

        public HomeController(ILogger<HomeController> logger, DataContext context, IHttpContextAccessor httpContextAccessor, UserManager<Gebruiker> userManager)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var vm = new IndexViewModel
                {
                    Handboeken = _context.Handboeken.ToList(),
                    Studenten = _context.Studenten.ToList(),
                    Vaklectoren = _context.Vaklectoren.ToList(),
                    Inschrijvingen = _context.Inschrijvingen.ToList(),
                    TemporarilyAccountCount =
                        _context.Gebruikers
                            .Where(gebruiker => gebruiker.IsTemporarilyAccount == true)
                            .Count()
                };

                return View("AdminDashboard", vm);
            }

            if (User.IsInRole("Student"))
            {
                return View("StudentDashboard");
            }

            if (User.IsInRole("Lector"))
            {
                return View("LectorDashboard");
            }

            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

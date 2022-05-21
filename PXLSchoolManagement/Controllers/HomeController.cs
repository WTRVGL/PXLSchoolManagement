using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using PXLSchoolManagement.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace PXLSchoolManagement.Controllers
{
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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login", new {area = "Identity"});
            }

            if (User.IsInRole("Admin"))
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

            return RedirectToAction("Privacy");            
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
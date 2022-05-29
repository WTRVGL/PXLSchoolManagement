using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Areas.Student.Models;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PXLSchoolManagement.Areas.Student.Controllers
{
    [Area("Student")]
    public class CursussenController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public CursussenController(DataContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Student")]
        public IActionResult Index()
        {
            var vm = new StudentCursussenIndexViewModel();
            vm.Cursussen = _context.Inschrijvingen
                .Include(i => i.Vak)
                .Include(i => i.Academiejaar)
                .Include(i => i.Studenten)
                .Include(i => i.Vaklectors)
                    .ThenInclude(v => v.Lector)
                    .ThenInclude(l => l.Gebruiker)
                .ToList();

            return View(vm);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Detail(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new StudentCursusDetailViewModel();
            vm.Cursus = _context.Inschrijvingen
                .Include(i => i.Vak)
                    .ThenInclude(v => v.Handboeken)
                .Include(i => i.Academiejaar)
                .Include(i => i.Studenten)
                    .ThenInclude(s => s.Gebruiker)
                .Include(i => i.Vaklectors)
                    .ThenInclude(v => v.Lector)
                    .ThenInclude(l => l.Gebruiker)
                .FirstOrDefault(i => i.Id == id);

            vm.IsIngeschreven = _context.Inschrijvingen
                .Where(i => i.Id == id)
                .SelectMany(i => i.Studenten)
                .Any(s => s.GebruikerId == user.Id);
            
            return View(vm);
        }
    }
}

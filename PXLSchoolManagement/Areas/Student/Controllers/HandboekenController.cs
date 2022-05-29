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
    public class HandboekenController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public HandboekenController(DataContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Student")]
        public IActionResult Index()
        {
            var vm = new StudentHandboekenIndexViewModel();
            vm.Handboeken = _context.Handboeken
                .Include(h => h.Vak)
                    .ThenInclude(v => v.Inschrijvingen)
                        .ThenInclude(i => i.Vaklectors)
                            .ThenInclude(v => v.Lector)
                                .ThenInclude(l => l.Gebruiker)
                .Include(i => i.Studenten)
                    .ThenInclude(v => v.Gebruiker)
                .ToList();

            return View(vm);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Detail(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new StudentHandboekDetailViewModel();

            var handboek = _context.Handboeken
                .Include(h => h.Vak)
                    .ThenInclude(v => v.Inschrijvingen)
                        .ThenInclude(i => i.Vaklectors)
                            .ThenInclude(v => v.Lector)
                                .ThenInclude(l => l.Gebruiker)
                .Include(i => i.Studenten)
                    .ThenInclude(v => v.Gebruiker)
                .FirstOrDefault(h => h.HandboekId == id);

            vm.Handboek = handboek;

            vm.InBezit = _context.Handboeken
            .Where(h => h.HandboekId == id)
            .SelectMany(h => h.Studenten)
            .Any(s => s.GebruikerId == user.Id);

            vm.VaklectorBoek = handboek.Vak.Inschrijvingen
                .FirstOrDefault()
                .Vaklectors.FirstOrDefault();

            return View(vm);
        }
    }
}

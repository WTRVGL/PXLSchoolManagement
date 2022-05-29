using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Areas.Lector.Models;
using PXLSchoolManagement.Areas.Student.Models;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PXLSchoolManagement.Areas.Lector.Controllers
{
    [Area("Lector")]
    public class HandboekenController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public HandboekenController(DataContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new LectorHandboekenIndexViewModel();
            vm.Handboeken = _context.Handboeken
                .Include(h => h.Vak)
                    .ThenInclude(v => v.Inschrijvingen)
                        .ThenInclude(i => i.Vaklectors)
                            .ThenInclude(v => v.Lector)
                                .ThenInclude(l => l.Gebruiker)
                .Include(i => i.Studenten)
                    .ThenInclude(v => v.Gebruiker)
                .Where(h => h.Vak.Inschrijvingen.FirstOrDefault().Vaklectors.FirstOrDefault().Lector.GebruikerId == user.Id)
                .ToList();

            return View(vm);
        }
    }
}

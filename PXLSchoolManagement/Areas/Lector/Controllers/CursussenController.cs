using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Areas.Lector.Models;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PXLSchoolManagement.Areas.Lector.Controllers
{
    [Area("Lector")]
    public class CursussenController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public CursussenController(DataContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var vm = new LectorCursussenIndexViewModel();
            vm.Cursussen = _context.Inschrijvingen
                .Include(i => i.Vaklectors)
                    .ThenInclude(v => v.Lector)
                        .ThenInclude(l => l.Gebruiker)
                .Include(i => i.Vak)
                .Include(i => i.Academiejaar)
                .Include(i => i.Studenten)
                .Where(i => i.Vaklectors.FirstOrDefault().Lector.GebruikerId == user.Id)
                .ToList();

            return View(vm);
        }
    }
}

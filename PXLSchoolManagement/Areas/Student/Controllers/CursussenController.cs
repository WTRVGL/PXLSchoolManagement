using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Areas.Student.Models;
using PXLSchoolManagement.Data;
using System.Linq;

namespace PXLSchoolManagement.Areas.Student.Controllers
{
    [Area("Student")]
    public class CursussenController : Controller
    {
        private readonly DataContext _context;

        public CursussenController(DataContext context)
        {
            _context = context;
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

    }
}

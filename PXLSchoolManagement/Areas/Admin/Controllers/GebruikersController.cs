#nullable disable
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Areas.Admin.Models;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;

namespace PXLSchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GebruikersController : Controller
    {
        private readonly DataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Gebruiker> _userManager;

        public GebruikersController(DataContext context, RoleManager<IdentityRole> roleManager, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Gebruikers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gebruikers.ToListAsync());
        }

        // GET: Gebruikers/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Gets selected user and includes Roles & RequestedRole
            var gebruiker = await _context.Gebruikers
                .Include(gebruiker => gebruiker.Roles)
                .Include(gebruiker => gebruiker.RequestedRole)
                .FirstOrDefaultAsync(m => m.Id == id.ToString());

            if (gebruiker == null)
            {
                return NotFound();
            }

            // Build basic View Model
            var vm = new GebruikerDetailViewModel
            {
                GebruikerId = id,
                Email = gebruiker.Email,
                Naam = gebruiker.Naam,
                Voornaam = gebruiker.Voornaam,
                Role = gebruiker.Roles.FirstOrDefault()
            };

            // If unverified account, include more properties
            if (gebruiker.IsTemporarilyAccount)
            {
                vm.RequestedRole = gebruiker.RequestedRole;
                vm.RequestedRoleId = gebruiker.RequestedRole.Id;
                vm.IsTemporarilyAccount = gebruiker.IsTemporarilyAccount;
            }

            return View(vm);
        }

        // GET: Gebruikers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebruikers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Naam,Voornaam,Email")] Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gebruiker);
        }

        // GET: Gebruikers/Edit/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers.FindAsync(id);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return View(gebruiker);
        }

        // POST: Gebruikers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Naam,Voornaam,Email")] Gebruiker gebruiker)
        {
            if (id != gebruiker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebruiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebruikerExists(gebruiker.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gebruiker);
        }

        // GET: Gebruikers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // POST: Gebruikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gebruiker = await _context.Gebruikers.FindAsync(id);
            _context.Gebruikers.Remove(gebruiker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebruikerExists(string id)
        {
            return _context.Gebruikers.Any(e => e.Id == id);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Verification()
        {
            var verifiableAccounts =
                _context.Gebruikers
                    .Where(gebruiker => gebruiker.IsTemporarilyAccount == true)
                        .Include(gebruiker => gebruiker.RequestedRole)
                    .ToList();
            return View(verifiableAccounts);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AcceptRole(GebruikerDetailViewModel vm)
        {
            var requestedRole = _context.Roles.FirstOrDefault(role => role.Id == vm.RequestedRoleId);
            var user = _context.Users.FirstOrDefault(gebruiker => gebruiker.Id == vm.GebruikerId);
            user.IsTemporarilyAccount = false;
            user.RequestedRole = null;

            await _userManager.AddToRoleAsync(user, requestedRole.Name);

            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

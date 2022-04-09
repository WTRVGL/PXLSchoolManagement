#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using PXLSchoolManagement.Models.ViewModels;

namespace PXLSchoolManagement.Controllers
{
    public class VaklectorsController : Controller
    {
        private readonly DataContext _context;

        public VaklectorsController(DataContext context)
        {
            _context = context;
        }

        // GET: Vaklectors
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Vaklectoren
                .Include(v => v.Lector)
                    .ThenInclude(l => l.Gebruiker)
                .Include(v => v.Inschrijvingen);
            var vaklectoren = await dataContext.ToListAsync();
            return View(vaklectoren);
        }

        // GET: Vaklectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaklector = await _context.Vaklectoren
                .Include(v => v.Lector)
                    .ThenInclude(l => l.Gebruiker)
                .Include(v => v.Inschrijvingen)
                .FirstOrDefaultAsync(m => m.VakLectorId == id);

            if (vaklector == null)
            {
                return NotFound();
            }

            return View(vaklector);
        }

        // GET: Vaklectors/Create
        public IActionResult Create()
        {
            var lectoren = _context.Lectoren
                .Include(l => l.Vaklector)
                .Include(l => l.Gebruiker)
                .Where(l => l.Vaklector == null)
                .ToList();

            var vm = new VaklectorViewModel();

            vm.Lectoren = 
                lectoren.Select(
                    l => new SelectListItem { 
                        Text = l.Gebruiker.VolledigeNaam, 
                        Value = l.LectorId.ToString() 
                    });

            return View(vm);
        }

        // POST: Vaklectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind()] VaklectorViewModel vm)
        {
            var lector = _context.Lectoren
                .Include(l => l.Gebruiker)
                .Include(l => l.Vaklector)
                .FirstOrDefault(l => vm.LectorId == l.LectorId);

            if (lector.Vaklector == null)
            {
                _context.Add(new Vaklector {  LectorId = vm.LectorId});
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Vaklectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaklector = await _context.Vaklectoren.FindAsync(id);
            if (vaklector == null)
            {
                return NotFound();
            }
            ViewData["LectorId"] = new SelectList(_context.Lectoren, "LectorId", "LectorId", vaklector.LectorId);
            return View(vaklector);
        }

        // POST: Vaklectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VakLectorId,LectorId")] Vaklector vaklector)
        {
            if (id != vaklector.VakLectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaklector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaklectorExists(vaklector.VakLectorId))
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
            ViewData["LectorId"] = new SelectList(_context.Lectoren, "LectorId", "LectorId", vaklector.LectorId);
            return View(vaklector);
        }

        // GET: Vaklectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaklector = await _context.Vaklectoren
                .Include(v => v.Lector)
                .FirstOrDefaultAsync(m => m.VakLectorId == id);
            if (vaklector == null)
            {
                return NotFound();
            }

            return View(vaklector);
        }

        // POST: Vaklectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaklector = await _context.Vaklectoren.FindAsync(id);
            _context.Vaklectoren.Remove(vaklector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaklectorExists(int id)
        {
            return _context.Vaklectoren.Any(e => e.VakLectorId == id);
        }
    }
}

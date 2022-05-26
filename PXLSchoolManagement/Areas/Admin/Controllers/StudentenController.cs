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
using PXLSchoolManagement.ViewModels;

namespace PXLSchoolManagement.Controllers
{
    [Area("Admin")]
    public class StudentenController : Controller
    {
        private readonly DataContext _context;

        public StudentenController(DataContext context)
        {
            _context = context;
        }

        // GET: Studenten
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Studenten.Include(s => s.Gebruiker);
            return View(await dataContext.ToListAsync());
        }

        // GET: Studenten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Studenten
                .Include(s => s.Gebruiker)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Studenten/Create
        public IActionResult Create()
        {
            var vm = new StudentViewModel();
            var gebruikers = _context.Studenten
                .Include(s => s.Gebruiker)
                .Where(s => s.Gebruiker.Id == s.GebruikerId);

            vm.Studenten = gebruikers.Select(
                    l => new SelectListItem
                    {
                        Text = l.Gebruiker.VolledigeNaam,
                        Value = l.Gebruiker.Id.ToString()
                    });

            return View(vm);
        }

        // POST: Studenten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,GebruikerId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", student.GebruikerId);
            return View(student);
        }

        // GET: Studenten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Studenten.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", student.GebruikerId);
            return View(student);
        }

        // POST: Studenten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,GebruikerId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", student.GebruikerId);
            return View(student);
        }

        // GET: Studenten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Studenten
                .Include(s => s.Gebruiker)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Studenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Studenten.FindAsync(id);
            _context.Studenten.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Studenten.Any(e => e.StudentId == id);
        }
    }
}

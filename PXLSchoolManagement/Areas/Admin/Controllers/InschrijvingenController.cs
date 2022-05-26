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

namespace PXLSchoolManagement.Controllers
{
    [Area("Admin")]
    public class InschrijvingenController : Controller
    {
        private readonly DataContext _context;

        public InschrijvingenController(DataContext context)
        {
            _context = context;
        }

        // GET: Inschrijvingen
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Inschrijvingen.Include(i => i.Academiejaar).Include(i => i.Vak);
            return View(await dataContext.ToListAsync());
        }

        // GET: Inschrijvingen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.Academiejaar)
                .Include(i => i.Vak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // GET: Inschrijvingen/Create
        public IActionResult Create()
        {
            ViewData["AcademiejaarId"] = new SelectList(_context.Academiejaren, "AcademiejaarId", "AcademiejaarId");
            ViewData["VakId"] = new SelectList(_context.Vakken, "Id", "Id");
            return View();
        }

        // POST: Inschrijvingen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(("Id,VakId,AcademiejaarId"))] Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inschrijving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademiejaarId"] = new SelectList(_context.Academiejaren, "AcademiejaarId", "AcademiejaarId", inschrijving.AcademiejaarId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "Id", "Id", inschrijving.VakId);
            return View(inschrijving);
        }

        // GET: Inschrijvingen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            if (inschrijving == null)
            {
                return NotFound();
            }
            ViewData["AcademiejaarId"] = new SelectList(_context.Academiejaren, "AcademiejaarId", "AcademiejaarId", inschrijving.AcademiejaarId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "Id", "Id", inschrijving.VakId);
            return View(inschrijving);
        }

        // POST: Inschrijvingen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VakId,AcademiejaarId")] Inschrijving inschrijving)
        {
            if (id != inschrijving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inschrijving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijving.Id))
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
            ViewData["AcademiejaarId"] = new SelectList(_context.Academiejaren, "AcademiejaarId", "AcademiejaarId", inschrijving.AcademiejaarId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "Id", "Id", inschrijving.VakId);
            return View(inschrijving);
        }

        // GET: Inschrijvingen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.Academiejaar)
                .Include(i => i.Vak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijvingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            _context.Inschrijvingen.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
            return _context.Inschrijvingen.Any(e => e.Id == id);
        }
    }
}

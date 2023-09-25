using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistema_unidades.Models;

namespace sistema_unidades.Controllers
{
    public class PeriodoesController : Controller
    {
        private readonly ClienteBdContext _context;

        public PeriodoesController(ClienteBdContext context)
        {
            _context = context;
        }

        // GET: Periodoes
        public async Task<IActionResult> Index()
        {
              return _context.Periodos != null ? 
                          View(await _context.Periodos.ToListAsync()) :
                          Problem("Entity set 'ClienteBdContext.Periodos'  is null.");
        }

        // GET: Periodoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Periodos == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // GET: Periodoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodo);
        }

        // GET: Periodoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periodos == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }

        // POST: Periodoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes")] Periodo periodo)
        {
            if (id != periodo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoExists(periodo.Id))
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
            return View(periodo);
        }

        // GET: Periodoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Periodos == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // POST: Periodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Periodos == null)
            {
                return Problem("Entity set 'ClienteBdContext.Periodos'  is null.");
            }
            var periodo = await _context.Periodos.FindAsync(id);
            if (periodo != null)
            {
                _context.Periodos.Remove(periodo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoExists(int id)
        {
          return (_context.Periodos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

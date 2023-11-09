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
    public class UnidadsController : Controller
    {
        private readonly ClienteBdContext _context;

        public UnidadsController(ClienteBdContext context)
        {
            _context = context;
        }

        public IActionResult UnidadesPorCliente(int clienteId)
        {
            var unidades = _context.Unidads.Where(u => u.IdCliente == clienteId).ToList();
            return View(unidades);
        }


        // GET: Unidads
        public async Task<IActionResult> Index()
        {
            var clienteBdContext = _context.Unidads.Include(u => u.IdClienteNavigation).Include(u => u.IdPeriodoNavigation).Include(u => u.IdTipoNavigation);
            return View(await clienteBdContext.ToListAsync());
        }

        // GET: Unidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidads == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads
                .Include(u => u.IdClienteNavigation)
                .Include(u => u.IdPeriodoNavigation)
                .Include(u => u.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidads/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["IdPeriodo"] = new SelectList(_context.Periodos, "Id", "Mes");
            ViewData["IdTipo"] = new SelectList(_context.Tipos, "Id", "Tipo1");
            return View();
        }

        // POST: Unidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Fecha,Folio,NSerie,IdCliente,Status,IdTipo,IdPeriodo")] Unidad unidad)
        {

            if (!ModelState.IsValid)
            {
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", unidad.IdCliente);
            ViewData["IdPeriodo"] = new SelectList(_context.Periodos, "Id", "Mes", unidad.IdPeriodo);
            ViewData["IdTipo"] = new SelectList(_context.Tipos, "Id", "Tipo1", unidad.IdTipo);
            return View(unidad);
        }

        // GET: Unidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidads == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", unidad.IdCliente);
            ViewData["IdPeriodo"] = new SelectList(_context.Periodos, "Id", "Mes", unidad.IdPeriodo);
            ViewData["IdTipo"] = new SelectList(_context.Tipos, "Id", "Tipo1", unidad.IdTipo);
            return View(unidad);
        }

        // POST: Unidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Fecha,Folio,NSerie,IdCliente,Status,IdTipo,IdPeriodo")] Unidad unidad)
        {
            if (id != unidad.Id)
            {   
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", unidad.IdCliente);
            ViewData["IdPeriodo"] = new SelectList(_context.Periodos, "Id", "Mes", unidad.IdPeriodo);
            ViewData["IdTipo"] = new SelectList(_context.Tipos, "Id", "Tipo1", unidad.IdTipo);
            return View(unidad);
        }

        // GET: Unidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidads == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads
                .Include(u => u.IdClienteNavigation)
                .Include(u => u.IdPeriodoNavigation)
                .Include(u => u.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidads == null)
            {
                return Problem("Entity set 'ClienteBdContext.Unidads'  is null.");
            }
            var unidad = await _context.Unidads.FindAsync(id);
            if (unidad != null)
            {
                _context.Unidads.Remove(unidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
          return (_context.Unidads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

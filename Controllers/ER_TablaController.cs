using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ER_proyecto.Data;
using ER_proyecto.Models;

namespace ER_proyecto.Controllers
{
    public class ER_TablaController : Controller
    {
        private readonly ER_proyectoContext _context;

        public ER_TablaController(ER_proyectoContext context)
        {
            _context = context;
        }

        // GET: ER_Tabla
        public async Task<IActionResult> Index()
        {
              return _context.ER_Tabla != null ? 
                          View(await _context.ER_Tabla.ToListAsync()) :
                          Problem("Entity set 'ER_proyectoContext.ER_Tabla'  is null.");
        }

        // GET: ER_Tabla/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ER_Tabla == null)
            {
                return NotFound();
            }

            var eR_Tabla = await _context.ER_Tabla
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (eR_Tabla == null)
            {
                return NotFound();
            }

            return View(eR_Tabla);
        }

        // GET: ER_Tabla/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ER_Tabla/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,Precio,Nombre,AceptarTerminos,Tiempo")] ER_Tabla eR_Tabla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eR_Tabla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eR_Tabla);
        }

        // GET: ER_Tabla/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ER_Tabla == null)
            {
                return NotFound();
            }

            var eR_Tabla = await _context.ER_Tabla.FindAsync(id);
            if (eR_Tabla == null)
            {
                return NotFound();
            }
            return View(eR_Tabla);
        }

        // POST: ER_Tabla/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cedula,Precio,Nombre,AceptarTerminos,Tiempo")] ER_Tabla eR_Tabla)
        {
            if (id != eR_Tabla.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eR_Tabla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ER_TablaExists(eR_Tabla.Cedula))
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
            return View(eR_Tabla);
        }

        // GET: ER_Tabla/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ER_Tabla == null)
            {
                return NotFound();
            }

            var eR_Tabla = await _context.ER_Tabla
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (eR_Tabla == null)
            {
                return NotFound();
            }

            return View(eR_Tabla);
        }

        // POST: ER_Tabla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ER_Tabla == null)
            {
                return Problem("Entity set 'ER_proyectoContext.ER_Tabla'  is null.");
            }
            var eR_Tabla = await _context.ER_Tabla.FindAsync(id);
            if (eR_Tabla != null)
            {
                _context.ER_Tabla.Remove(eR_Tabla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ER_TablaExists(int id)
        {
          return (_context.ER_Tabla?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAcademico.Data;
using AppAcademico.Models;

namespace AppAcademico.Controllers
{
    public class PruebasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PruebasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pruebas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prueba.ToListAsync());
        }

        // GET: Pruebas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.Prueba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }

            return View(prueba);
        }

        // GET: Pruebas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pruebas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prueba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }

        // GET: Pruebas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.Prueba.FindAsync(id);
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre")] Prueba prueba)
        {
            if (id != prueba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prueba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PruebaExists(prueba.Id))
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
            return View(prueba);
        }

        // GET: Pruebas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prueba = await _context.Prueba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }

            return View(prueba);
        }

        // POST: Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prueba = await _context.Prueba.FindAsync(id);
            _context.Prueba.Remove(prueba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PruebaExists(int id)
        {
            return _context.Prueba.Any(e => e.Id == id);
        }
    }
}

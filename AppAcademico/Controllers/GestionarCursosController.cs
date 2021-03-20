using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAcademico.Data;
using AppAcademico.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppAcademico.Controllers
{
    public class GestionarCursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestionarCursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GestionarCursos
        [Authorize(Roles = "Administrador,Profesor")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursos.ToListAsync());
        }

        // GET: GestionarCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.Cursos
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (cursos == null)
            {
                return NotFound();
            }

            return View(cursos);
        }

        // GET: GestionarCursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GestionarCursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurso,NombreCurso,Usuario")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursos);
        }

        // GET: GestionarCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.Cursos.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }
            return View(cursos);
        }

        // POST: GestionarCursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCurso,NombreCurso,Usuario")] Cursos cursos)
        {
            if (id != cursos.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursosExists(cursos.IdCurso))
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
            return View(cursos);
        }

        // GET: GestionarCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.Cursos
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (cursos == null)
            {
                return NotFound();
            }

            return View(cursos);
        }

        // POST: GestionarCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursos = await _context.Cursos.FindAsync(id);
            _context.Cursos.Remove(cursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursosExists(int id)
        {
            return _context.Cursos.Any(e => e.IdCurso == id);
        }

        // GET: Evaluacion
        public async Task<IActionResult> Evaluacion()
        {
            return View(await _context.Eval.ToListAsync());
        }

        // GET: Estudiantes
        public async Task<IActionResult> Estudiante()
        {
            return View(await _context.Estudiante.ToListAsync());
        }
    }
}

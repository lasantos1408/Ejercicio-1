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
    public class CursosAsignadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosAsignadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CursosAsignados
        //[Authorize(Roles = "Administrador")]
        //[Authorize(Roles = "Profesor")]
        //[Authorize(Roles = "Alumno")]
        //[Authorize(Roles = "Basico")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CursosAsignados.ToListAsync());
        }

        // GET: CursosAsignados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursosAsignados = await _context.CursosAsignados
                .FirstOrDefaultAsync(m => m.IdCursosAsignados == id);
            if (cursosAsignados == null)
            {
                return NotFound();
            }

            return View(cursosAsignados);
        }

        // GET: CursosAsignados/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> item = _context.Cursos.Select(c => new SelectListItem { Value = c.IdCurso.ToString(), Text = c.NombreCurso });

            ViewBag.cursoLista = item;

            return View();
        }

        // POST: CursosAsignados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurso,NombreCurso,Usuario,IdCursosAsignados")] CursosAsignados cursosAsignados)
        {
            if (ModelState.IsValid)
            {
                var curso = await _context.Cursos.FindAsync(cursosAsignados.IdCurso);

                cursosAsignados.Usuario = User.Identity.Name;
                cursosAsignados.NombreCurso = curso.NombreCurso;

                _context.Add(cursosAsignados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursosAsignados);
        }

        // GET: CursosAsignados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            IEnumerable<SelectListItem> item = _context.Cursos.Select(c => new SelectListItem { Value = c.IdCurso.ToString(), Text = c.NombreCurso });

            ViewBag.cursoLista = item;

            if (id == null)
            {
                return NotFound();
            }

            var cursosAsignados = await _context.CursosAsignados.FindAsync(id);
            if (cursosAsignados == null)
            {
                return NotFound();
            }
            return View(cursosAsignados);
        }

        // POST: CursosAsignados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCurso,NombreCurso,Usuario,IdCursosAsignados")] CursosAsignados cursosAsignados)
        {
            var curso = await _context.Cursos.FindAsync(cursosAsignados.IdCurso);

            cursosAsignados.Usuario = User.Identity.Name;
            cursosAsignados.NombreCurso = curso.NombreCurso;
            if (id != cursosAsignados.IdCursosAsignados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursosAsignados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursosAsignadosExists(cursosAsignados.IdCursosAsignados))
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
            return View(cursosAsignados);
        }

        // GET: CursosAsignados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursosAsignados = await _context.CursosAsignados
                .FirstOrDefaultAsync(m => m.IdCursosAsignados == id);
            if (cursosAsignados == null)
            {
                return NotFound();
            }

            return View(cursosAsignados);
        }

        // POST: CursosAsignados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursosAsignados = await _context.CursosAsignados.FindAsync(id);
            _context.CursosAsignados.Remove(cursosAsignados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursosAsignadosExists(int id)
        {
            return _context.CursosAsignados.Any(e => e.IdCursosAsignados == id);
        }

        // GET: Evaluacion
        public async Task<IActionResult> Evaluacion()
        {
            return View(await _context.Eval.ToListAsync());
        }
    }
}

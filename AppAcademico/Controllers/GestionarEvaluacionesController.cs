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
    public class GestionarEvaluacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestionarEvaluacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GestionarEvaluaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eval.ToListAsync());
        }

        // GET: GestionarEvaluaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eval = await _context.Eval
                .FirstOrDefaultAsync(m => m.IdEval == id);

            TempData["identifCurso"] = eval.IdCurso;
            if (eval == null)
            {
                return NotFound();
            }

            return View(eval);
        }

        // GET: GestionarEvaluaciones/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> item = _context.Cursos.Select(c => new SelectListItem { Value = c.IdCurso.ToString(), Text = c.NombreCurso });

            ViewBag.cursoLista = item;

            return View();
        }

        // POST: GestionarEvaluaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEval,nota,IdCurso")] Eval eval)
        {
            TempData["identifCurso"] = eval.IdCurso;
            if (ModelState.IsValid)
            {
                _context.Add(eval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eval);
        }

        // GET: GestionarEvaluaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eval = await _context.Eval.FindAsync(id);
            TempData["identifCurso"] = eval.IdCurso;
            if (eval == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> item = _context.Cursos.Select(c => new SelectListItem { Value = c.IdCurso.ToString(), Text = c.NombreCurso });

            ViewBag.cursoLista = item;

            return View(eval);
        }

        // POST: GestionarEvaluaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEval,nota,IdCurso")] Eval eval)
        {
            TempData["identifCurso"] = eval.IdCurso;
            if (id != eval.IdEval)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvalExists(eval.IdEval))
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
            return View(eval);
        }

        // GET: GestionarEvaluaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eval = await _context.Eval
                .FirstOrDefaultAsync(m => m.IdEval == id);
            TempData["identifCurso"] = eval.IdCurso;
            if (eval == null)
            {
                return NotFound();
            }

            return View(eval);
        }

        // POST: GestionarEvaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eval = await _context.Eval.FindAsync(id);
            _context.Eval.Remove(eval);
            TempData["identifCurso"] = eval.IdCurso;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvalExists(int id)
        {
            return _context.Eval.Any(e => e.IdEval == id);
        }
    }
}

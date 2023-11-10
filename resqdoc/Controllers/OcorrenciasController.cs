using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResqDoc.Models;
using resqdoc.Models;

namespace resqdoc.Controllers
{
    public class OcorrenciasController : Controller
    {
        private readonly Context _context;

        public OcorrenciasController(Context context)
        {
            _context = context;
        }

        // GET: Ocorrencias
        public async Task<IActionResult> Index()
        {
              return _context.Ocorrencia != null ? 
                          View(await _context.Ocorrencia.ToListAsync()) :
                          Problem("Entity set 'Context.Ocorrencia'  is null.");
        }

        // GET: Ocorrencias/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // GET: Ocorrencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocorrencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Gravidade,Data,Cobrade,Id")] Ocorrencia ocorrencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocorrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocorrencia);
        }

        // GET: Ocorrencias/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }
            return View(ocorrencia);
        }

        // POST: Ocorrencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Titulo,Gravidade,Data,Cobrade,Id")] Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocorrencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcorrenciaExists(ocorrencia.Id))
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
            return View(ocorrencia);
        }

        // GET: Ocorrencias/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Ocorrencia == null)
            {
                return Problem("Entity set 'Context.Ocorrencia'  is null.");
            }
            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia != null)
            {
                _context.Ocorrencia.Remove(ocorrencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcorrenciaExists(long id)
        {
          return (_context.Ocorrencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

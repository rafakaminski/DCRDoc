using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using resqdoc.Models;

namespace resqdoc.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly Context _context;

        public MaterialsController(Context context)
        {
            _context = context;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
              return _context.Material != null ? 
                          View(await _context.Material.ToListAsync()) :
                          Problem("Entity set 'Context.Material'  is null.");
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Tipo,Quantidade,Local,Cidadao,Id")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Titulo,Tipo,Quantidade,Local,Cidadao,Id")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Material == null)
            {
                return Problem("Entity set 'Context.Material'  is null.");
            }
            var material = await _context.Material.FindAsync(id);
            if (material != null)
            {
                _context.Material.Remove(material);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(long id)
        {
          return (_context.Material?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

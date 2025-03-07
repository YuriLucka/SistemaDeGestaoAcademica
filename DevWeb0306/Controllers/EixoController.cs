using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevWeb0306.Data;
using DevWeb0306.Models;

namespace DevWeb0306.Controllers
{
    public class EixoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EixoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eixo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eixo.ToListAsync());
        }

        // GET: Eixo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eixo = await _context.Eixo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eixo == null)
            {
                return NotFound();
            }

            return View(eixo);
        }

        // GET: Eixo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eixo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Eixo eixo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eixo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eixo);
        }

        // GET: Eixo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eixo = await _context.Eixo.FindAsync(id);
            if (eixo == null)
            {
                return NotFound();
            }
            return View(eixo);
        }

        // POST: Eixo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Eixo eixo)
        {
            if (id != eixo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eixo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EixoExists(eixo.Id))
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
            return View(eixo);
        }

        // GET: Eixo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eixo = await _context.Eixo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eixo == null)
            {
                return NotFound();
            }

            return View(eixo);
        }

        // POST: Eixo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eixo = await _context.Eixo.FindAsync(id);
            if (eixo != null)
            {
                _context.Eixo.Remove(eixo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EixoExists(int id)
        {
            return _context.Eixo.Any(e => e.Id == id);
        }
    }
}

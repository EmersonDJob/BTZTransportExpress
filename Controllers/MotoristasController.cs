using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTZTransportExpress.Data;
using BTZTransportExpress.Models;
using Microsoft.AspNetCore.Authorization;

namespace BTZTransportExpress.Controllers
{
    [Authorize]
    public class MotoristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotoristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motoristas.ToListAsync());
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,CNH,CategoriaCNH,DataNascimento,Status")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,CNH,CategoriaCNH,DataNascimento,Status")] Motorista motorista)
        {
            if (id != motorista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.Id))
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
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            _context.Motoristas.Remove(motorista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(int id)
        {
            return _context.Motoristas.Any(e => e.Id == id);
        }
    }
}

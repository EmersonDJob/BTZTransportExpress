using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTZTransportExpress.Data;
using BTZTransportExpress.Models;
using BTZTransportExpress.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BTZTransportExpress.Controllers
{
    [Authorize]
    public class AbastecimentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbastecimentoesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool ValidarAbastecimento(Abastecimento abastecimento)
        {
            var retorno = false;
            var veiculo = _context.Veiculos.Where(x => x.Id == abastecimento.VeiculoId).FirstOrDefault();

            if (veiculo.TipoCombustivel == abastecimento.TipoCombustivel)
            {
                if (veiculo.MaxTanque >= abastecimento.QuantidadeCombustivel)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        // GET: Abastecimentoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Abastecimentos.Include(a => a.Motorista).Include(a => a.Veiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Abastecimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimentos
                .Include(a => a.Motorista)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abastecimento == null)
            {
                return NotFound();
            }

            return View(abastecimento);
        }

        // GET: Abastecimentoes/Create
        public IActionResult Create()
        {
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas.Where(m => m.Status == true), "Id", "Nome");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Placa");
            return View();
        }

        // POST: Abastecimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VeiculoId,MotoristaId,Data,TipoCombustivel,QuantidadeCombustivel,ValorTotal")] Abastecimento abastecimento)
        {
            if (ModelState.IsValid)
            {
                if (ValidarAbastecimento(abastecimento))
                {
                    if(abastecimento.TipoCombustivel== TipoCombustivel.Gasolina)
                    {
                        abastecimento.ValorTotal = abastecimento.QuantidadeCombustivel * 4.29;

                    }else if (abastecimento.TipoCombustivel == TipoCombustivel.Etanol)
                    {
                        abastecimento.ValorTotal = abastecimento.QuantidadeCombustivel * 2.99;
                    }else
                    {
                        abastecimento.ValorTotal = abastecimento.QuantidadeCombustivel * 2.09;
                    }
                        _context.Add(abastecimento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
  
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "Nome", abastecimento.MotoristaId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Placa", abastecimento.VeiculoId);
            //return View(abastecimento);
            return RedirectToAction(nameof(Index));
        }

        // GET: Abastecimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimentos.FindAsync(id);
            if (abastecimento == null)
            {
                return NotFound();
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "Nome", abastecimento.MotoristaId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Placa", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // POST: Abastecimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VeiculoId,MotoristaId,Data,TipoCombustivel,QuantidadeCombustivel,ValorTotal")] Abastecimento abastecimento)
        {
            if (id != abastecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (ValidarAbastecimento(abastecimento))
                {
                    try
                    {
                        if (abastecimento.TipoCombustivel == TipoCombustivel.Gasolina)
                        {
                            abastecimento.ValorTotal = abastecimento.QuantidadeCombustivel * 4.29;

                        }
                        else if (abastecimento.TipoCombustivel == TipoCombustivel.Etanol)
                        {
                            abastecimento.ValorTotal = abastecimento.QuantidadeCombustivel * 2.99;
                        }
                        else
                        {
                            abastecimento.ValorTotal = abastecimento.QuantidadeCombustivel * 2.09;
                        }

                        _context.Update(abastecimento);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AbastecimentoExists(abastecimento.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "Nome", abastecimento.MotoristaId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "PLaca", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // GET: Abastecimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimentos
                .Include(a => a.Motorista)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abastecimento == null)
            {
                return NotFound();
            }

            return View(abastecimento);
        }

        // POST: Abastecimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abastecimento = await _context.Abastecimentos.FindAsync(id);
            _context.Abastecimentos.Remove(abastecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbastecimentoExists(int id)
        {
            return _context.Abastecimentos.Any(e => e.Id == id);
        }
    }
}

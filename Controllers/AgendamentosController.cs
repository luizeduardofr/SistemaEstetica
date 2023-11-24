using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEstetica2.Models;

namespace SistemaEstetica.Controllers
{
    [Authorize]
    public class AgendamentosController : Controller
    {
        private readonly Contexto _context;

        public AgendamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Agendamentos.Include(a => a.cliente).Include(a => a.funcionario).Include(a => a.servico);
            return View(await contexto.ToListAsync());
        }

        // GET: Agendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.cliente)
                .Include(a => a.funcionario)
                .Include(a => a.servico)
                .FirstOrDefaultAsync(m => m.id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            ViewData["clienteID"] = new SelectList(_context.Clientes, "id", "nome");
            ViewData["funcionarioID"] = new SelectList(_context.Funcionarios, "id", "nome");
            ViewData["servicoID"] = new SelectList(_context.Servicos, "id", "descricao");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,reservaData,reservaHorario,funcionarioID,clienteID,servicoID")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                //Movimentar a qtde de Horarios disponiveis diminuindo em 1
                Funcionario funcionario = await _context.Funcionarios.FindAsync(agendamento.funcionarioID);
                funcionario.vagas = funcionario.vagas - 1;


                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteID"] = new SelectList(_context.Clientes, "id", "nome", agendamento.clienteID);
            ViewData["funcionarioID"] = new SelectList(_context.Funcionarios, "id", "nome", agendamento.funcionarioID);
            ViewData["servicoID"] = new SelectList(_context.Servicos, "id", "descricao", agendamento.servicoID);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["clienteID"] = new SelectList(_context.Clientes, "id", "nome", agendamento.clienteID);
            ViewData["funcionarioID"] = new SelectList(_context.Funcionarios, "id", "nome", agendamento.funcionarioID);
            ViewData["servicoID"] = new SelectList(_context.Servicos, "id", "descricao", agendamento.servicoID);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,reservaData,reservaHorario,funcionarioID,clienteID,servicoID")] Agendamento agendamento)
        {
            if (id != agendamento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.id))
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
            ViewData["clienteID"] = new SelectList(_context.Clientes, "id", "nome", agendamento.clienteID);
            ViewData["funcionarioID"] = new SelectList(_context.Funcionarios, "id", "nome", agendamento.funcionarioID);
            ViewData["servicoID"] = new SelectList(_context.Servicos, "id", "descricao", agendamento.servicoID);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.cliente)
                .Include(a => a.funcionario)
                .Include(a => a.servico)
                .FirstOrDefaultAsync(m => m.id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agendamentos == null)
            {
                return Problem("Entity set 'Contexto.Agendamentos'  is null.");
            }
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);

                //Movimentar a qtde de Horarios disponiveis aumentando em 1
                Funcionario funcionario = await _context.Funcionarios.FindAsync(agendamento.funcionarioID);
                funcionario.vagas = funcionario.vagas + 1;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
          return _context.Agendamentos.Any(e => e.id == id);
        }
    }
}

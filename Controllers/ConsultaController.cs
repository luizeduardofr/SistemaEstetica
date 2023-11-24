using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEstetica2.Models;

namespace SistemaEstetica.Controllers
{
    [Authorize]
    public class ConsultaController : Controller
    {
        private readonly Contexto contexto;

        public ConsultaController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Filtrar()
        {
            return View();
        }

        public ActionResult agendCliente(string busca) 
        {
            var agCliente = contexto.Agendamentos.Include(cli=>cli.cliente)
                                                 .Include(func=>func.funcionario)
                                                 .Include(serv=>serv.servico)
                                                 .Where(func=>func.funcionario.nome == busca)
                                                 .ToList();
            return View(agCliente);
        }
    }
}

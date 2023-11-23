using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEstetica2.Models;

namespace SistemaEstetica.Controllers
{
    public class DadosController : Controller
    {
        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Cliente()
        {
            contexto.Database.ExecuteSqlRaw("delete from clientes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('clientes', RESEED, 0)");

            Random randNum = new Random();

            string[] vNomeMas = { "Lucas", "Arthur", "Bernardo", "Heitor", "Davi" };
            string[] vNomeFem = { "Evelyn", "Ketlen", "Victoria", "Beatriz", "Giovanna" };

            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente();

                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.cpf = "111.111.111-1" + (i + 1).ToString();
                cliente.telefone = "(11)11111-11" + (i + 1).ToString();
                cliente.email = cliente.nome + "@outlook.com".ToString();
                contexto.Clientes.Add(cliente);
            }
            contexto.SaveChanges();

            return View(contexto.Clientes.OrderBy(o => o.id).ToList());
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEstetica2.Models;

namespace SistemaEstetica.Controllers
{
    [Authorize]
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
            string[] vCpf = { "111.111.111-", "222.222.222-" };
            string[] vTelefone = { "(11)11111-1111", "(22)22222-2222", "(33)33333-3333", "(44)44444-4444", "(55)55555-5555" };
            string[] vEmail = { "@outlook.com", "@gmail.com", "@hotmail.com" };

            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente();

                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.cpf = vCpf[randNum.Next() % 2] + (i + 1).ToString();
                cliente.telefone = vTelefone[randNum.Next() % 5];
                cliente.email = cliente.nome + vEmail[randNum.Next() % 3];
                contexto.Clientes.Add(cliente);
            }
            contexto.SaveChanges();

            return View(contexto.Clientes.OrderBy(o => o.id).ToList());
        }

        public IActionResult Funcionario()
        {
            contexto.Database.ExecuteSqlRaw("delete from funcionarios");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('funcionarios', RESEED, 0)");

            Random randNum = new Random();

            string[] vNomeMas = { "Pedro", "Guilherme", "Anderson", "Eduardo", "Gabriel" };
            string[] vNomeFem = { "Amanda", "Fernanda", "Helena", "Thais", "Rafaela" };
            string[] vCpf = { "111.111.111-", "222.222.222-" };
            string[] vTelefone = { "(11)11111-1111", "(22)22222-2222", "(33)33333-3333", "(44)44444-4444", "(55)55555-5555" };
            string[] vEmail = { "@outlook.com", "@gmail.com", "@hotmail.com" };

            for (int i = 0; i < 10; i++)
            {
                Funcionario funcionario = new Funcionario();

                funcionario.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                funcionario.nascimento = randNum.Next(16,40);
                funcionario.cpf = vCpf[randNum.Next() % 2] + (i + 1).ToString();
                funcionario.telefone = vTelefone[randNum.Next() % 5];
                funcionario.email = funcionario.nome + vEmail[randNum.Next() % 3];
                funcionario.vagas = randNum.Next(8, 12);
                contexto.Funcionarios.Add(funcionario);
            }
            contexto.SaveChanges();

            return View(contexto.Funcionarios.OrderBy(o => o.id).ToList());
        }

        public IActionResult Servico()
        {
            contexto.Database.ExecuteSqlRaw("delete from servicos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('servicos', RESEED, 0)");

            Random randNum = new Random();

            string[] vDescricao = { "Corte", "Luzes", "Unha Mão", "Unha Pé", "Cilios" };
            string[] vDescricao2 = { "Progressiva", "Selagem", "Escova", "Tratamento Capilar", "Sobrancelha" };

            for (int i = 0; i < 10; i++)
            {
                Servico servico = new Servico();

                servico.descricao = (i % 2 == 0) ? vDescricao[i / 2] : vDescricao2[i / 2];
                servico.preco = randNum.Next(25, 200);
                contexto.Servicos.Add(servico);
            }
            contexto.SaveChanges();

            return View(contexto.Servicos.OrderBy(o => o.id).ToList());
        }
    }
}

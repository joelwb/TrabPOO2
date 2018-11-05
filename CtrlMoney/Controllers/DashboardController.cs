using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using EntityAcessoDados;
using Microsoft.AspNet.Identity;
using CtrlMoney.Annotations;

namespace CtrlMoney.Controllers
{
    public class DashboardController : Controller
    {
        private CtrlMoneyDbContext dbContext = new CtrlMoneyDbContext();


        // GET: Dashboard
        [Authorize]
        [SelecionadorMesFilter]
        public ActionResult VisaoGeral(int ano, int mes)
        {
            string userId = User.Identity.GetUserId();

            DateTime inicioMes = new DateTime(ano, mes, 1);
            DateTime finalMes = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));

            List<Despesa> despesas = dbContext.Despesas.Where(p => p.Pessoa.Id == userId && p.DataCompra > inicioMes && p.DataCompra < finalMes).ToList();
            List<Receita> receitas = dbContext.Receitas.Where(p => p.Pessoa.Id == userId && p.DataRecebimento > inicioMes && p.DataRecebimento < finalMes).ToList();

            ViewData["TotalDespesa"] = despesas.Sum(p => p.Valor);
            ViewData["TotalReceita"] = receitas.Sum(p => p.Valor);
            ViewData["Caixa"] = (decimal) ViewData["TotalReceita"] - (decimal) ViewData["TotalDespesa"];

            foreach (CategoriaDespesa item in Enum.GetValues(typeof(CategoriaDespesa)))
            {
               ViewData["CategoriaDespesa" + item] = despesas.Where(p => p.Categoria.Equals(item)).Sum(p => p.Valor);
            }

            foreach (CategoriaReceita item in Enum.GetValues(typeof(CategoriaReceita)))
            {
                ViewData["CategoriaReceita" + item] = receitas.Where(p => p.Categoria.Equals(item)).Sum(p => p.Valor);
            }

            return View();
        }
    }
}
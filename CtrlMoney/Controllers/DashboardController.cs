using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using EntityAcessoDados;
using Microsoft.AspNet.Identity;
using CtrlMoney.Annotations;
using APL;

namespace CtrlMoney.Controllers
{
    public class DashboardController : Controller
    {
        private ReceitaAPL receitasAPL = new ReceitaAPL();
        private DespesaAPL despesasAPL = new DespesaAPL();


        // GET: Dashboard
        [Authorize]
        [SelecionadorMesFilter]
        public ActionResult VisaoGeral(int ano, int mes)
        {
            string userId = User.Identity.GetUserId();

            List<Despesa> despesas = despesasAPL.Listar(userId, ano, mes);
            List<Receita> receitas = receitasAPL.Listar(userId, ano, mes);

            ViewData["TotalDespesa"] = despesas.Sum(p => p.Valor);
            ViewData["TotalReceita"] = receitas.Sum(p => p.Valor);
            ViewData["Caixa"] = (decimal)ViewData["TotalReceita"] - (decimal)ViewData["TotalDespesa"];

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                despesasAPL.Dispose();
                receitasAPL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    
}
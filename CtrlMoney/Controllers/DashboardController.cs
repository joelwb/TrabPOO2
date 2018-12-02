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
using CtrlMoney.ViewModel;
using CtrlMoney.Models;

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


            return View(new VisaoGeralDirector(despesas,receitas,receitasAPL).build());
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
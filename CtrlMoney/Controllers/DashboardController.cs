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

            Dictionary<string, decimal> categoriaDespesaValue = new Dictionary<string, decimal>();
            foreach (CategoriaDespesa item in Enum.GetValues(typeof(CategoriaDespesa)))
            {
                decimal valor = 0;
                valor += despesas.Where(p => p is Parcelamento && p.Categoria.Equals(item)).Cast<Parcelamento>().Sum(p => p.Valor / p.NumParcelas);
                valor += despesas.Where(p => p is SemParcelamento && p.Categoria.Equals(item)).Cast<SemParcelamento>().Sum(p => p.Valor);
                categoriaDespesaValue[item.ToString()] = valor;
            }

            Dictionary<string, decimal> categoriaReceitaValue = receitasAPL.GetAllReceitasMes(receitas);

            decimal totalDespesa = categoriaDespesaValue.Values.Sum();
            decimal totalReceita = categoriaReceitaValue.Values.Sum();
            decimal caixa = totalReceita - totalDespesa;

            VisaoGeralViewModel viewModel = new VisaoGeralViewModel(totalDespesa, totalReceita, caixa, categoriaDespesaValue, categoriaReceitaValue);

            return View(viewModel);
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
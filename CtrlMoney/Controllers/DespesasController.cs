using APL;
using AutoMapper;
using CtrlMoney.Annotations;
using CtrlMoney.ViewModel.Despesas;
using Dominio;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CtrlMoney.Controllers
{
    public class DespesasController : Controller
    {
        private DespesaAPL despesasAPL = new DespesaAPL();
        private PessoaUsuarioAPL pessoaUsuarioAPL = new PessoaUsuarioAPL();

        [Authorize]
        [SelecionadorMesFilter]
        public ActionResult Index(int ano, int mes, CategoriaDespesa categoria)
        {
            string userId = User.Identity.GetUserId();

            List<Despesa> despesas = despesasAPL.listar(userId, ano, mes).Where(p => p.Categoria == categoria).ToList();
            ViewBag.Categoria = categoria;
            return View(Mapper.Map<List<Despesa>, List<DespesaViewModel>>(despesas));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSemParcelamento([Bind(Exclude = "Id")] SemParcelamentoViewModel viewModel) 
        {
            if (ModelState.IsValid)
            {
                SemParcelamento semParcelamento = Mapper.Map<SemParcelamentoViewModel, SemParcelamento>(viewModel);
                semParcelamento.FormaPag = FormaPag.Dinheiro;
                semParcelamento.PessoaId = pessoaUsuarioAPL.SelecionarById(User.Identity.GetUserId()).Id;
                despesasAPL.Inserir(semParcelamento);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateParcelamento([Bind(Exclude = "Id")] ParcelamentoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Parcelamento parcelamento = Mapper.Map<ParcelamentoViewModel, Parcelamento>(viewModel);
                parcelamento.FormaPag = FormaPag.Cartao;
                parcelamento.PessoaId = pessoaUsuarioAPL.SelecionarById(User.Identity.GetUserId()).Id;
                despesasAPL.Inserir(parcelamento);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                despesasAPL.Dispose();
                pessoaUsuarioAPL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
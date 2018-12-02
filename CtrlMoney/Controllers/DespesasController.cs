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

            List<Despesa> despesas = despesasAPL.Listar(userId, ano, mes).Where(p => p.Categoria == categoria).ToList();
            List<Parcelamento> parcelamentos = despesas.Where(p => p is Parcelamento).Cast<Parcelamento>().ToList();
            List<SemParcelamento> semParcelamentos = despesas.Where(p => p is SemParcelamento).Cast<SemParcelamento>().ToList();

            List<DespesaViewModel> viewModels = new List<DespesaViewModel>();
            viewModels.AddRange(Mapper.Map<List<Parcelamento>, List<ParcelamentoViewModel>>(parcelamentos));
            viewModels.AddRange(Mapper.Map<List<SemParcelamento>, List<SemParcelamentoViewModel>>(semParcelamentos));

            ViewBag.Categoria = categoria;
            List<Cartao> cartoes = pessoaUsuarioAPL.SelecionarById(userId).Pessoa.Cartoes.ToList();
            SelectList dropDownCartoes = new SelectList(cartoes, "Id", "Nome");
            ViewBag.Cartoes = dropDownCartoes;
            return View(viewModels);
        }


        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSemParcelamento(SemParcelamentoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SemParcelamento semParcelamento = Mapper.Map<SemParcelamentoViewModel, SemParcelamento>(viewModel);
                semParcelamento.FormaPag = FormaPag.Dinheiro;
                semParcelamento.PessoaId = pessoaUsuarioAPL.SelecionarById(User.Identity.GetUserId()).Id;
                despesasAPL.Alterar(semParcelamento);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditParcelamento(ParcelamentoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Parcelamento parcelamento = Mapper.Map<ParcelamentoViewModel, Parcelamento>(viewModel);
                parcelamento.FormaPag = FormaPag.Cartao;
                parcelamento.PessoaId = pessoaUsuarioAPL.SelecionarById(User.Identity.GetUserId()).Id;
                despesasAPL.Alterar(parcelamento);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Despesa despesa = despesasAPL.SelecionarById(id);
            if (despesa.PessoaId == User.Identity.GetUserId()) despesasAPL.Deletar(despesa);
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
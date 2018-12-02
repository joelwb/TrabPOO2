using APL;
using AutoMapper;
using CtrlMoney.Annotations;
using CtrlMoney.ViewModel;
using Dominio;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CtrlMoney.Controllers
{
    public class ReceitasController : Controller
    {
        private ReceitaAPL receitasAPL = new ReceitaAPL();
        private PessoaUsuarioAPL pessoaUsuarioAPL = new PessoaUsuarioAPL();

        [Authorize]
        [SelecionadorMesFilter]
        public ActionResult Index(int ano, int mes, CategoriaReceita categoria)
        {
            string userId = User.Identity.GetUserId();

            List<Receita> receitas = receitasAPL.Listar(userId, ano, mes).Where(p => p.Categoria == categoria).ToList();
            ViewBag.Categoria = categoria;
            return View(Mapper.Map<List<Receita>, List<ReceitaViewModel>>(receitas));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReceita([Bind(Exclude = "Id")] ReceitaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Receita receita = Mapper.Map<ReceitaViewModel, Receita>(viewModel);
                receita.PessoaId = pessoaUsuarioAPL.SelecionarById(User.Identity.GetUserId()).Id;
                receitasAPL.Inserir(receita);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReceita(ReceitaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Receita receita = Mapper.Map<ReceitaViewModel, Receita>(viewModel);
                receita.PessoaId = pessoaUsuarioAPL.SelecionarById(User.Identity.GetUserId()).Id;
                receitasAPL.Alterar(receita);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Receita receita = receitasAPL.SelecionarById(id);
            if (receita.PessoaId == User.Identity.GetUserId()) receitasAPL.Deletar(receita);
            return Redirect(Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                receitasAPL.Dispose();
                pessoaUsuarioAPL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
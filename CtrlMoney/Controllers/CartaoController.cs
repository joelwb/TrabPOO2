﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APL;
using AutoMapper;
using CtrlMoney.ViewModel;
using Dominio;
using EntityAcessoDados;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CtrlMoney.Controllers
{
    public class CartaoController : Controller
    {
        CartaoAPL apl = new CartaoAPL();
        PessoaUsuarioAPL apl_pessoa = new PessoaUsuarioAPL();

        // GET: Cartao
        [Authorize]
        public ActionResult Index()
        {
            string id_usuario = User.Identity.GetUserId();

            DateTime data_atual = DateTime.Now;
            int mes = data_atual.Month;
            ViewBag.mes = --mes;
            ViewBag.meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                                            "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};
            ViewBag.ano = data_atual.Year;

            

            List<Cartao> cartoes = apl.SelecionarPorPessoa(id_usuario);
            List<CartaoViewModel> cartoesVM = new List<CartaoViewModel>();

            foreach (Cartao item in cartoes)
            {
                cartoesVM.Add(Mapper.Map<Cartao, CartaoViewModel>(item));
            }

            return View(cartoesVM);
        }

        // GET: Cartao/Details/5
        public ActionResult Details(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartoes.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }*/
            return View(/*cartao*/);
        }

        // GET: Cartao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cartao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Limite,DiaFechamento,DiaVencimento,Numero")] CartaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Cartao cartao = Mapper.Map<CartaoViewModel, Cartao>(viewModel);

                string id_usuario = User.Identity.GetUserId();
                Usuario usuario = apl_pessoa.SelecionarById(id_usuario);
                Pessoa pessoa = usuario.Pessoa;
                pessoa.Cartoes.Add(cartao);
                apl_pessoa.Alterar(pessoa, usuario);
                
                return RedirectToAction("Index");
            } else {
                ModelState.AddModelError("erro_identity", "Não foi possivel salvar");
                return View(viewModel);
            }
            
        }

        // GET: Cartao/Edit/5
        public ActionResult Edit(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartoes.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }*/
            return View(/*cartao*/);
        }

        // POST: Cartao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Limite,DiaFechamento,DiaVencimento,Numero")] Cartao cartao)
        {
            /*if (ModelState.IsValid)
            {
                db.Entry(cartao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return View(/*cartao*/);
        }

        // GET: Cartao/Delete/5
        public ActionResult Delete(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = db.Cartoes.Find(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }*/
            return View(/*cartao*/);
        }

        // POST: Cartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*Cartao cartao = db.Cartoes.Find(id);
            db.Cartoes.Remove(cartao);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }*/
            base.Dispose(disposing);
        }
    }
}

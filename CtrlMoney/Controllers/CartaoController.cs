using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APL;
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

        // GET: Cartao
        [Authorize]
        public ActionResult Index()
        {
            string id_usuario = User.Identity.GetUserId();

            List<Cartao> cartoes = apl.listarCartoes(id_usuario);

            return View(cartoes);
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
        public ActionResult Create([Bind(Include = "Id,Nome,Limite,DiaFechamento,DiaVencimento,Numero")] Cartao cartao)
        {
            /*if (ModelState.IsValid)
            {
                db.Cartoes.Add(cartao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            */
            return View(/*cartao*/);
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

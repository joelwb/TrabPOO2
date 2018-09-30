using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CtrlMoney.Identity;
using CtrlMoney.ViewModel.PessoaUsuario;
using Dominio;
using EntityAcessoDados;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CtrlMoney.Controllers
{
    public class UsuariosController : Controller
    {
        private CtrlMoneyDbContext db = new CtrlMoneyDbContext();

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        

        

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            Pessoa pessoa = db.Pessoas.Find(id);

            db.Usuarios.Remove(usuario);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }







        // GET: Usuarios/SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: Usuarios/SignIn
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn([Bind(Include = "Login,Senha,Nome,CPF,DataNasc")] PessoaUsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new IdentityEntityContext());
                var userManager = new UserManager<IdentityUser>(userStore);

                var identityUser = new IdentityUser
                {
                    Email = viewModel.Login,
                    UserName = viewModel.Login
                };

                IdentityResult result = userManager.Create(identityUser, viewModel.Senha);

                if (result.Succeeded)
                {
                    Login(identityUser, userManager);

                    Usuario usuario = Mapper.Map<PessoaUsuarioViewModel, Usuario>(viewModel);
                    Pessoa pessoa = Mapper.Map<PessoaUsuarioViewModel, Pessoa>(viewModel);

                    usuario.Pessoa = pessoa;
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", "Não é possivel fazer o cadastro com essas informações");
                }
            }

            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AutenticacaoViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new IdentityEntityContext());
                var userManager = new UserManager<IdentityUser>(userStore);

                var identityUser = userManager.Find(viewModel.Email, viewModel.Senha);

                if (identityUser == null)
                {
                    ModelState.AddModelError("erro_identity", "Email ou senha inválidos");
                    return View(viewModel);
                }

                Login(identityUser, userManager);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(viewModel);
            }
        }

        private void Login(IdentityUser identityUser, UserManager<IdentityUser> userManager)
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            var identity = userManager.CreateIdentity(identityUser, DefaultAuthenticationTypes.ApplicationCookie);

            authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
            {
                IsPersistent = false
            }, identity);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

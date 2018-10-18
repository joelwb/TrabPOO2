using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APL;
using AutoMapper;
using CtrlMoney.Identity;
using CtrlMoney.ViewModel.PessoaUsuario;
using Dominio;
using EntityAcessoDados;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CtrlMoney.Controllers
{
    public class IdentityController : Controller
    {
        PessoaUsuarioAPL apl = new PessoaUsuarioAPL();

        // GET: Usuarios/Perfil/5
        [Authorize]
        public ActionResult Perfil() 
        {
            // TODO Pedir confirmação se deseja apagar ou salvar as alterações
            // TODO Corrigir exibição da data de nascimento, pois não está aparecendo, mas está no html

            string userId = User.Identity.GetUserId();
            Usuario usuario = apl.SelecionarById(userId);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            PessoaUsuarioViewModel viewModel = Mapper.Map<Usuario, PessoaUsuarioViewModel>(usuario);
            
            return View(viewModel);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Perfil([Bind(Include = "Login,Senha,Nome,CPF,DataNasc")] PessoaUsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Id = User.Identity.GetUserId();

                Usuario usuario = Mapper.Map<PessoaUsuarioViewModel, Usuario>(viewModel);
                Pessoa pessoa = Mapper.Map<PessoaUsuarioViewModel, Pessoa>(viewModel);
                pessoa.CPF = pessoa.CPF.Replace(".", "").Replace("-", "");

                apl.Alterar(pessoa, usuario);
                return RedirectToAction("Index","Home");
            }else {
                ModelState.AddModelError("erro_identity", "Não foi possivel salvar");
                return View(viewModel);
            }

        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete()
        {
            var userStore = new UserStore<IdentityUser>(new IdentityEntityContext());
            var userManager = new UserManager<IdentityUser>(userStore);

            var userId = User.Identity.GetUserId();
            var identityUser = userManager.FindById(userId);

            var logins = identityUser.Logins;

            foreach (var login in logins)
            {
                userManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            IdentityResult result = userManager.Delete(identityUser);
            Usuario usuario = apl.SelecionarById(userId);

            if (result.Succeeded)
            {
                Pessoa pessoa = usuario.Pessoa;

                apl.Deletar(pessoa, usuario);
                return RedirectToAction("Logoff");
            }else
            {
                PessoaUsuarioViewModel viewModel = Mapper.Map<Usuario, PessoaUsuarioViewModel>(usuario);
                ModelState.AddModelError("erro_identity", "Não foi possivel apagar a conta");
                return View("Perfil", viewModel);
            }
        }

        // GET: Usuarios/SignUp
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            if (!User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        // POST: Usuarios/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SignUp([Bind(Include = "Login,Senha,Nome,CPF,DataNasc")] PessoaUsuarioViewModel viewModel)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new IdentityEntityContext());
                var userManager = new UserManager<IdentityUser>(userStore);

                //Serve para permitir caracteres especiais no email 
                //Na verdade é no username, mas como vamos o email como username... vai ter que permitir de qualquer forma
                var userValidator = new UserValidator<IdentityUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                userManager.UserValidator = userValidator;

                var identityUser = new IdentityUser
                {
                    Email = viewModel.Login,
                    UserName = viewModel.Login
                };

                IdentityResult result = userManager.Create(identityUser, viewModel.Senha);

                if (result.Succeeded)
                {
                    // TODO Enviar confirmação para o email
                    Login(identityUser, userManager, false);

                    viewModel.Id = identityUser.Id;

                    //TODO Criptografar a senha
                    Usuario usuario = Mapper.Map<PessoaUsuarioViewModel, Usuario>(viewModel);
                    Pessoa pessoa = Mapper.Map<PessoaUsuarioViewModel, Pessoa>(viewModel);
                    pessoa.CPF = pessoa.CPF.Replace(".", "").Replace("-", "");

                    apl.Inserir(pessoa, usuario);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", "Não é possivel fazer o cadastro com essas informações");
                }
            }

            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(AutenticacaoViewModel viewModel, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            // TODO Criar na view link para recuperar a conta e logicamente uma action e view para essa funcionalidade
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

                Login(identityUser, userManager, viewModel.Lembrar);

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

        private void Login(IdentityUser identityUser, UserManager<IdentityUser> userManager, bool lembrar)
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            var identity = userManager.CreateIdentity(identityUser, DefaultAuthenticationTypes.ApplicationCookie);

            authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
            {
                IsPersistent = lembrar
            }, identity);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult AlterarSenha(string senhaAtual, string novaSenha)
        {
            var userId= User.Identity.GetUserId();

            var userStore = new UserStore<IdentityUser>(new IdentityEntityContext());
            var userManager = new UserManager<IdentityUser>(userStore);

            var userValidator = new UserValidator<IdentityUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            userManager.UserValidator = userValidator;

            var result = userManager.ChangePassword(userId, senhaAtual, novaSenha);

            object resposta;

            if (result.Succeeded)
            {
                resposta = new
                {
                    response = "funcionou"
                };

                Usuario usuario = apl.SelecionarById(userId);

                usuario.Senha = novaSenha;
                apl.Alterar(usuario.Pessoa, usuario);
            }
            else
            {
                resposta = new
                {
                    response = "erro"
                };
            }

            return Json(resposta);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                apl.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

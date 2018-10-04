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
        private CtrlMoneyDbContext db = new CtrlMoneyDbContext();

        // GET: Usuarios/Perfil/5
        // TODO Talvez seria banaca receber uma view model para exibir possiveis erros de outras actions
        // Como a Post Perfil e Delete,
        // Se esse viewModel for null simplesmente carrega do BD
        // Senão só exibe o viewModel do parametro
        [Authorize]
        public ActionResult Perfil() 
        {
            // TODO Pedir confirmação se deseja apagar ou salvar as alterações
            // TODO Corrigir exibição da data de nascimento, pois não está aparecendo, mas está no html
            string userId = User.Identity.GetUserId();
            Usuario usuario = db.Usuarios.Include(p => p.Pessoa).SingleOrDefault(p => p.Id == userId);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            PessoaUsuarioViewModel pessoaUsuario = Mapper.Map<Usuario, PessoaUsuarioViewModel>(usuario);

            return View(pessoaUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Perfil([Bind(Include = "Login,Senha,Nome,CPF,DataNasc")] PessoaUsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO Fazer update no Identity

                // TODO Trocar na view o campo de senha por algo como um botão que aciona um modal
                //para editar a senha e que tenha os campos: senha atual, nova senha e confirmação

                viewModel.Id = User.Identity.GetUserId();

                Usuario usuario = Mapper.Map<PessoaUsuarioViewModel, Usuario>(viewModel);
                Pessoa pessoa = Mapper.Map<PessoaUsuarioViewModel, Pessoa>(viewModel);

                db.Entry(usuario).State = EntityState.Modified;
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            // TODO se a action Get de Perfil for alterada para receber um ViewModel de parametro
            // Descomentar código a seguir

            // ModelState.AddModelError("erro_identity", "Não foi possivel apagar a conta");
            // return View(viewModel)

            return View();
        }

        // POST: Usuarios/Delete/5
        // TODO talves seria interessante receber o ViewModel como Parametro para caso ocorra um erro retornar
        // retornar para a action que a chamou (no caso a action get do Perfil) e passar o ViewModel para ela
        // veja como se retorna o erro nas ultimas linha da action
        // Obviamente se for feito isso deve-se colocar um if pra validar o ViewModel como já é feito nas outras actions
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

            if (result.Succeeded)
            {
                Usuario usuario = db.Usuarios.Find(userId);
                Pessoa pessoa = db.Pessoas.Find(userId);

                db.Usuarios.Remove(usuario);
                db.Pessoas.Remove(pessoa);
                db.SaveChanges();
                return RedirectToAction("Logoff");
            }else
            {
                // TODO se a action Get de Perfil for alterada para receber um ViewModel de parametro
                // Descomentar código a seguir

                // ModelState.AddModelError("erro_identity", "Não foi possivel apagar a conta");
                // return View(viewModel)

                return HttpNotFound();
            }
        }

        // GET: Usuarios/SignUp
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: Usuarios/SignUp
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SignUp([Bind(Include = "Login,Senha,Nome,CPF,DataNasc")] PessoaUsuarioViewModel viewModel)
        {
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
                    Login(identityUser, userManager);

                    viewModel.Id = identityUser.Id;

                    //TODO Criptografar a senha
                    Usuario usuario = Mapper.Map<PessoaUsuarioViewModel, Usuario>(viewModel);
                    Pessoa pessoa = Mapper.Map<PessoaUsuarioViewModel, Pessoa>(viewModel);

                    new PessoaUsuarioAPL().Inserir(pessoa, usuario);

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(AutenticacaoViewModel viewModel, string returnUrl)
        {
            // TODO Criar checkbox na view e um atributo boolean no ViewModel para Manter conta logada para sempre.
            // TODO Criar na view link para recuperar a conta e logicamente uma action e view para essa funcionalidade
            if (ModelState.IsValid)
            {
                // TODO Logar somente quando usuario estiver com email confirmado

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




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

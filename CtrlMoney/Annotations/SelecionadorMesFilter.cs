using APL;
using CtrlMoney.Identity;
using EntityAcessoDados;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CtrlMoney.Annotations
{
    public class SelecionadorMesFilter : FilterAttribute, IActionFilter
    {
        private PessoaUsuarioAPL apl = new PessoaUsuarioAPL();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int ano = Convert.ToInt32(filterContext.HttpContext.Request.QueryString["ano"]);
            int mes = Convert.ToInt32(filterContext.HttpContext.Request.QueryString["mes"]);
            string categoria = filterContext.HttpContext.Request.QueryString["categoria"];

            string queryCategoria = categoria != null ? "&categoria=" + categoria : "";

            string url = filterContext.HttpContext.Request.Url.AbsolutePath;

            int minMonth = 1;
            int maxMonth = 12;

            int anoCadastro = 0;

            if (ano == 0 || mes == 0)
            {
                ano = DateTime.Today.Year;
                mes = DateTime.Today.Month;
                filterContext.HttpContext.Response.Redirect(url + "?mes=" + mes + "&ano=" + ano + queryCategoria);
            }
            else
            {
                int anoCorreto = ano;
                int mesCorreto = mes;

                var userStore = new UserStore<IdentityUser>(new IdentityEntityContext());
                var userManager = new UserManager<IdentityUser>(userStore);

                string userName = filterContext.HttpContext.User.Identity.Name;
                IdentityUser user = userManager.FindByName(userName);

                DateTime dataCadastro;
                try
                {
                    dataCadastro = apl.SelecionarById(user.Id).DataCadastro;
                }catch (Exception e)
                {
                    dataCadastro = DateTime.Today;
                }

                anoCadastro = dataCadastro.Year;

                if (ano > DateTime.Today.Year) anoCorreto = DateTime.Today.Year;
                else if (ano < dataCadastro.Year) anoCorreto = dataCadastro.Year;
                else if (ano == dataCadastro.Year) minMonth = dataCadastro.Month;
                else if (ano == DateTime.Today.Year) maxMonth = DateTime.Today.Month;

                if (mes >= DateTime.Today.Month && ano == DateTime.Today.Year)
                {
                    mesCorreto = DateTime.Today.Month;
                    maxMonth = mesCorreto;
                }
                if (mes <= dataCadastro.Month && ano == dataCadastro.Year)
                {
                    mesCorreto = dataCadastro.Month;
                    minMonth = mesCorreto;
                }

                if (ano != anoCorreto || mes != mesCorreto)
                    filterContext.HttpContext.Response.Redirect(url + "?mes=" + mesCorreto + "&ano=" + anoCorreto + queryCategoria);
            }


            filterContext.Controller.ViewBag.MesSelecionado = --mes;
            filterContext.Controller.ViewBag.AnoSelecionado = ano;
            filterContext.Controller.ViewBag.AnoCadastro = anoCadastro;
            filterContext.Controller.ViewBag.QueryCategoria = queryCategoria;
            filterContext.Controller.ViewBag.MinMonth = --minMonth;
            filterContext.Controller.ViewBag.MaxMonth = --maxMonth;
        }

    }
}
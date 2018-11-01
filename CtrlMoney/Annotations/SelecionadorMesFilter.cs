using APL;
using EntityAcessoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            int? ano = Convert.ToInt32(filterContext.HttpContext.Request.QueryString["ano"]);
            int? mes = Convert.ToInt32(filterContext.HttpContext.Request.QueryString["mes"]);

            string url = filterContext.HttpContext.Request.Url.AbsolutePath;
          
            if (ano == null || mes == null)
            {
                ano = DateTime.Today.Year;
                mes = DateTime.Today.Month;


            }
            else
            {
                string userName = filterContext.HttpContext.User.Identity.Name;
                DateTime dataCadastro = apl.SelecionarById(userName).DataCadastro;

                if (ano > DateTime.Today.Year) ano = DateTime.Today.Year;
                else if (ano < dataCadastro.Year) ano = dataCadastro.Year;

                if (mes > DateTime.Today.Month && ano == DateTime.Today.Year) mes = DateTime.Today.Month;
                if (mes < dataCadastro.Month && ano == dataCadastro.Year) mes = dataCadastro.Month;
            }

            filterContext.HttpContext.Response.Redirect(url + "?mes=" + mes + "&ano=" + ano);
        }

    }
}
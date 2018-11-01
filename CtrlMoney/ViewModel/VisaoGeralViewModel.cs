using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CtrlMoney.ViewModel
{
    public class VisaoGeralViewModel
    {
        public class DashboardViewModel 
        {
            // site para visuzalizar
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/nerddinner/use-viewdata-and-implement-viewmodel-classes

            // Properties
            public List<Despesa> despesas { get;  set; }
            public List<Receita> receitas  { get; set; }
            DateTime hoje { get; set; }
            DateTime inicioMes { get; set; }
            DateTime finalMes { get; set; }
            string month { get; set; }


            
        }
      
    }
}
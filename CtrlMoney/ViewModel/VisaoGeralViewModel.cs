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

         List<Receita> receita { get; set; }
         List<Despesa> despesa { get; set; }



        }
      
    }
}
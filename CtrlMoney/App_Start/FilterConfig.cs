using CtrlMoney.Annotations;
using System.Web;
using System.Web.Mvc;

namespace CtrlMoney
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SelecionadorMesFilter());
        }
    }
}

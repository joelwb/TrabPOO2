using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CtrlMoney.ViewModel
{
    public class GraficoDoughnutViewModel
    {
        public string IdGrafico { get; set; }

        public List<string> Labels { get; set; }

        public List<string> Data { get; set; }

        public List<string> Colors { get; set; }
    }
}
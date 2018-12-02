using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CtrlMoney.ViewModel
{
    public class VisaoGeralViewModel
    {
        public VisaoGeralViewModel(decimal totalDespesa, decimal totalReceita, decimal caixa, Dictionary<string, decimal> categoriaDespesaValue, Dictionary<string, decimal> categoriaReceitaValue)
        {
            TotalDespesa = totalDespesa;
            TotalReceita = totalReceita;
            Caixa = caixa;
            CategoriaDespesaValue = categoriaDespesaValue;
            CategoriaReceitaValue = categoriaReceitaValue;
        }

        [Display(Name = "Despesas")]
        public decimal TotalDespesa { get; set; }

        [Display(Name = "Receitas")]
        public decimal TotalReceita { get; set; }

        [Display(Name = "Caixa")]
        public decimal Caixa { get; set; }


        public Dictionary<string, decimal> CategoriaDespesaValue { get; set; }
        public Dictionary<string, decimal> CategoriaReceitaValue { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using APL;
using CtrlMoney.ViewModel;

namespace CtrlMoney.Models
{
    public class VisaoGeralVMBuilder
    {

        private decimal TotalDespesa { get; set; }
        private decimal TotalReceita { get; set; }
        private decimal Caixa { get; set; }
        private Dictionary<string, decimal> CategoriaDespesaValue { get; set; }
        private Dictionary<string, decimal> CategoriaReceitaValue { get; set; }

        public VisaoGeralVMBuilder calcTotalDespesa()
        {
            TotalDespesa = CategoriaDespesaValue.Values.Sum();
            return this;
        }

        public VisaoGeralVMBuilder calcTotalReceita()
        {
            TotalReceita = CategoriaReceitaValue.Values.Sum();
            return this;
        }

        public VisaoGeralVMBuilder calcCaixa()
        {
            Caixa = TotalReceita - TotalDespesa;
            return this;
        }

        public VisaoGeralVMBuilder ctrCategoriaDespesa(List<Despesa> despesas)
        {
            CategoriaDespesaValue = new Dictionary<string, decimal>();
            foreach (CategoriaDespesa item in Enum.GetValues(typeof(CategoriaDespesa)))
            {
                decimal valor = 0;
                valor += despesas.Where(p => p is Parcelamento && p.Categoria.Equals(item)).Cast<Parcelamento>().Sum(p => p.Valor / p.NumParcelas);
                valor += despesas.Where(p => p is SemParcelamento && p.Categoria.Equals(item)).Cast<SemParcelamento>().Sum(p => p.Valor);
                CategoriaDespesaValue[item.ToString()] = valor;
            }
            return this;
        }

        public VisaoGeralVMBuilder ctrCategoriaReceita(List<Receita> receitas, ReceitaAPL receitaAPL)
        {
            CategoriaReceitaValue = receitaAPL.GetAllReceitasMes(receitas);
            return this;
        }

        public VisaoGeralViewModel build()
        {
            return new VisaoGeralViewModel(TotalDespesa, TotalReceita, Caixa, CategoriaDespesaValue, CategoriaReceitaValue);
        } 
    }
}
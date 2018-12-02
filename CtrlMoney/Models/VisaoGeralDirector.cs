using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using APL;
using CtrlMoney.ViewModel;

namespace CtrlMoney.Models
{
    public class VisaoGeralDirector
    {
        private List<Despesa> despesas;
        private List<Receita> receitas;
        private ReceitaAPL receitaAPL;

        public VisaoGeralDirector(List<Despesa> despesas, List<Receita> receitas, ReceitaAPL receitaAPL)
        {
            this.despesas = despesas;
            this.receitas = receitas;
            this.receitaAPL = receitaAPL;
        }

        public VisaoGeralViewModel build()
        {
            return new VisaoGeralVMBuilder()
                .ctrCategoriaDespesa(despesas)
                .ctrCategoriaReceita(receitas, receitaAPL)
                .calcTotalDespesa()
                .calcTotalReceita()
                .calcCaixa()
                .build();
        }
    }
}
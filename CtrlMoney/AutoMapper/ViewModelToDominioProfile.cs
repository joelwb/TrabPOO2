using AutoMapper;
using CtrlMoney.ViewModel;
using CtrlMoney.ViewModel;
using CtrlMoney.ViewModel.Despesas;
using CtrlMoney.ViewModel.PessoaUsuario;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CtrlMoney.AutoMapper
{
    public class ViewModelToDominioProfile : Profile
    {

        public ViewModelToDominioProfile()
        {
            CreateMap<PessoaUsuarioViewModel, Pessoa>();
            CreateMap<PessoaUsuarioViewModel, Usuario>();
            CreateMap<ParcelamentoViewModel, Parcelamento>();
            CreateMap<SemParcelamentoViewModel, SemParcelamento>();
            CreateMap<ReceitaViewModel, Receita>();
            CreateMap<CartaoViewModel, Cartao>();
        }
    }
}
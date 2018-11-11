using AutoMapper;
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
    public class DominioToViewModelProfile : Profile
    {
        public DominioToViewModelProfile()
        {
            CreateMap<Pessoa, PessoaUsuarioViewModel>()
                .ForMember(p => p.Login, opt => opt.MapFrom(src => src.Usuario.Login))
                .ForMember(p => p.Senha, opt => opt.MapFrom(src => src.Usuario.Senha));

            CreateMap<Usuario, PessoaUsuarioViewModel>()
                .ForMember(p => p.Nome, opt => opt.MapFrom(src => src.Pessoa.Nome))
                .ForMember(p => p.CPF, opt => opt.MapFrom(src => src.Pessoa.CPF))
                .ForMember(p => p.DataNasc, opt => opt.MapFrom(src => src.Pessoa.DataNasc));

            CreateMap<SemParcelamento, DespesaViewModel>();
            CreateMap<Parcelamento, DespesaViewModel>();

            CreateMap<Receita, ReceitaViewModel>();
        }
    }
}
using AutoMapper;
using CtrlMoney.ViewModel;
using CtrlMoney.ViewModel.Despesas;
using CtrlMoney.ViewModel;
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
            CreateMap<Cartao, CartaoViewModel>()
                .ForMember(c => c.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(c => c.Limite, opt => opt.MapFrom(src => src.Limite))
                .ForMember(c => c.DiaFechamento, opt => opt.MapFrom(src => src.DiaFechamento))
                .ForMember(c => c.DiaVencimento, opt => opt.MapFrom(src => src.DiaVencimento))
                .ForMember(c => c.Numero, opt => opt.MapFrom(src => src.Numero));


            CreateMap<SemParcelamento, DespesaViewModel>();
            CreateMap<Parcelamento, DespesaViewModel>();

            CreateMap<Receita, ReceitaViewModel>();
        }
    }
}
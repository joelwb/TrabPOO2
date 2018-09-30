using AutoMapper;
using CtrlMoney.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CtrlMoney.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DominioToViewModelProfile>();
                cfg.AddProfile<ViewModelToDominioProfile>();
            });
        }
    }
}
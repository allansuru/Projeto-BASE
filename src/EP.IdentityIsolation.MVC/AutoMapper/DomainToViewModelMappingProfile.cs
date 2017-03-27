using AutoMapper;
using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EP.IdentityIsolation.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
      
            CreateMap<ClienteViewModel,Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<ImagensProdutoViewModel, ImagensProduto>();
        }
    }
}
using AutoMapper;
using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.MVC.ViewModels;

namespace EP.IdentityIsolation.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure() //Install-Package AutoMapper -Version 4.2.1
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<ImagensProduto, ImagensProdutoViewModel>();
        }
    }
}
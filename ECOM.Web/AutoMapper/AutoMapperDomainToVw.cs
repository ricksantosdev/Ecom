using AutoMapper;
using ECOM.Domain.Entities;
using ECOM.Web.ViewModels;


namespace ECOM.Web.AutoMapper
{
    public  class AutoMapperDomainToVw  : Profile
    {
        public AutoMapperDomainToVw()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Menu, MenuViewModels>();
            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>();
            CreateMap<Fornecedores, FornecedorViewModels>();
            CreateMap<FormaPagto, FormaPagtoViewModels>();
        }
    }
}
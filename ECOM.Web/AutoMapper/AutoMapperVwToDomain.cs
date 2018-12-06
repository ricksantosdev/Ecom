using AutoMapper;
using ECOM.Domain.Entities;
using ECOM.Web.ViewModels;


namespace ECOM.Web.AutoMapper
{
    public class AutoMapperVwToDomain  : Profile
    {
        public AutoMapperVwToDomain()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<MenuViewModels, Menu>();
            CreateMap<CategoriaProdutoViewModel, CategoriaProduto>();
            CreateMap<FornecedorViewModels, Fornecedores>();
            CreateMap<FormaPagtoViewModels, FormaPagto>();
        }

    }
}
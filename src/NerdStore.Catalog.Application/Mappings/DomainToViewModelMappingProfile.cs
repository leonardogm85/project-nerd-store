using AutoMapper;
using NerdStore.Catalog.Application.ViewModels;
using NerdStore.Catalog.Domain.Entities;

namespace NerdStore.Catalog.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();

            CreateMap<Product, ProductViewModel>()
                .ForMember(v => v.Width, m => m.MapFrom(p => p.Dimension.Width))
                .ForMember(v => v.Height, m => m.MapFrom(p => p.Dimension.Height))
                .ForMember(v => v.Depth, m => m.MapFrom(p => p.Dimension.Depth));
        }
    }
}

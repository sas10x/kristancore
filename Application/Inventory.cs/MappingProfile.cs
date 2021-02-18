using System.Linq;
using AutoMapper;
using Domain;

namespace Application.Inventory
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Zmpq25b, ItemDto>()
                .ForMember(d => d.Article, o => o.MapFrom(s => s.Article))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Barcode, o => o.MapFrom(s => s.Gtin))
            ;
        }
    }
}
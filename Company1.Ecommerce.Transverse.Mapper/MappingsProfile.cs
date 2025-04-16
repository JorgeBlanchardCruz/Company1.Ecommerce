using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Transverse.Mapper;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        //CreateMap<Customers, CustomersDTO>().ReverseMap()
        //    .ForMember(dest => dest.CustomerId, source => source.MapFrom(src => src.CustomerId))
        //    .ForMember(dest => dest.CompanyName, source => source.MapFrom(src => src.CompanyName))
        //    .ForMember(dest => dest.ContactName, source => source.MapFrom(src => src.ContactName))
        //    .ForMember(dest => dest.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
        //    .ForMember(dest => dest.Address, source => source.MapFrom(src => src.Address))
        //    .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
        //    .ForMember(dest => dest.Region, source => source.MapFrom(src => src.Region))
        //    .ForMember(dest => dest.PostalCode, source => source.MapFrom(src => src.PostalCode))
        //    .ForMember(dest => dest.Country, source => source.MapFrom(src => src.Country))
        //    .ForMember(dest => dest.Phone, source => source.MapFrom(src => src.Phone))
        //    .ForMember(dest => dest.Fax, source => source.MapFrom(src => src.Fax));

        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}

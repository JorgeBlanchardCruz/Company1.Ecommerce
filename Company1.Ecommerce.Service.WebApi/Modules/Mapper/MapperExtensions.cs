using Company1.Ecommerce.Transverse.Mapper;

namespace Company1.Ecommerce.Service.WebApi.Modules.Mapper;

public static class MapperExtensions
{
    public static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
    }
}

using WatchDog;
using WatchDog.src.Enums;

namespace Company1.Ecommerce.Service.WebApi.Modules.Watch;

public static class WatchDogExtensions
{
    public static IServiceCollection AddWatchLog(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWatchDogServices(options =>
        {
            options.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
            options.DbDriverOption = WatchDogDbDriverEnum.MSSQL;
            options.IsAutoClear = true;
            options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
        });
        return services;
    }
}

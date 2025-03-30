using AutoMapper;
using WebApi.Mapping.NotificationMapping;

namespace WebApi.Extensions;

public static class NotificationAutomapper
{
    /// <summary>
    /// Инициализация маппера
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection InstallAutomapper(this IServiceCollection service)
    {
        service.AddSingleton<IMapper>(new Mapper(GetConfigurationMapper()));
        return service;
    }

    private static MapperConfiguration GetConfigurationMapper()
    {
        var config = new MapperConfiguration(cnf =>
        {
            cnf.AddProfile<NotificationMappingProfile>();
            cnf.AddProfile<Services.Implementations.Mapping.NotificationMappingProfile>();
        });
        config.AssertConfigurationIsValid();
        return config;
    }
}
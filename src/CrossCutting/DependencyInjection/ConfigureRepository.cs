using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
    }
}
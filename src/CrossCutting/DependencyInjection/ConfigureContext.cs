using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection;

public class ConfigureContext
{
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<MyContext>(
            option => option.UseMySQL(
                "Server=localhost;Port=3306;Database=dbPessoaCrud;Uid=root;Pwd=Ismael-753951!"
            )
        );
    }
}
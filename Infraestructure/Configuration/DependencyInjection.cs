using Infraestructure.Mapers;
using Infraestructure.Repositories.Commands;
using Infraestructure.Repositories.Queries;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infraestructure.Mapers;
using Shared.Infraestructure.Repositories.Commands;
using Shared.Infraestructure.Repositories.Queries;



namespace Infraestructure.Configuration;



/// <summary>
/// Clase que se encarga de registrar las dependencias necesarias por la capa de infraestructura.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Método que extiende a IServiceCollection para registrar las dependencias. De este modo, quien utilice este proyecto, podrá
    /// registrar las dependencias de una forma sencilla y no tendrá que saber qué depenencias internas tiene este proyecto.
    /// </summary>
    /// <param name="paramServices">El gestor de dependencias.</param>
    /// <returns></returns>
    public static IServiceCollection InstallInfraestructureDependencies(this IServiceCollection paramServices)
    {
        paramServices
            .AddScoped<ICountriesCommandUnitOfWork, CountriesUnitOfWorkCommandEntityCore8SqlLite>()
            .AddScoped<ICountriesQueryRepository, CountriesRepositoryQueryEntityCore8Sqlite>()
            .AddSingleton<IMaperToDomain, MaperToDomain>();


        return paramServices;
    }
}

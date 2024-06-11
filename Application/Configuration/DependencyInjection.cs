using Microsoft.Extensions.DependencyInjection;
using Infraestructure.Repositories.Commands;
using Shared.Infraestructure.CountryRequester;
using Infraestructure.CountriesRequester;
using Shared.Infraestructure.Repositories.Commands;



namespace Application.Configuration;



/// <summary>
/// Clase que registra en el contenedor de dependencias todas las dependencias que se necesitan en la librería.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection InstallApplicationDependencies(this IServiceCollection paramServices)
    {
        paramServices.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });



        paramServices
            .AddScoped<ICountriesCommandUnitOfWork, CountriesUnitOfWorkCommandEntityCore8SqlLite>()
            .AddSingleton<ICountriesRequester, CountriesRequesterRestCountries>();

        return paramServices;
    }
}

using Application.Configuration;
using Infraestructure.Configuration;
using Infraestructure.CountriesRequester;
using Infraestructure.Repositories.Interfaces;



namespace WebApi.Configuration;



/// <summary>
/// Clase que se encarga de registrar todas las dependencias que se utilizarán en la aplicación.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection InstallDependencies(
    this IServiceCollection paramServicios,
    IConfiguration paramConfiguracion)
    {
        //Se registran todas las dependencias de la aplicación, las que requiere el API directamente como el resto de dependencias
        //del resto de capas.
        //Cada proyecto registra las dependencias que necesita, para ello definen sus propios métodos que extiende a IServiceCollection
        //por lo que se pueden utilizar aquí.
        paramServicios
            .AddHttpClient()
            .AddSingleton<IWebApiAddress, WebApiAddress>()
            .AddSingleton<IConnectionString, ConnectionString>()
            .InstallApplicationDependencies()
            .InstallInfraestructureDependencies();



        return paramServicios;
    }
}

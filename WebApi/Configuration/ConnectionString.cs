using Infraestructure.Repositories.Interfaces;



namespace WebApi.Configuration;



/// <summary>
/// Una implementación para obtener la cadena de conexión que se utilizará para el acceso a datos a través del repositorio.<para/><para/>
/// 
/// De este modo se puede inyectar como dependencia en al intanciación del repositorio.
/// </summary>
public class ConnectionString : IConnectionString
{
    private readonly IConfiguration _configuration;

    public ConnectionString(IConfiguration paramConfiguration)
    {
        _configuration = paramConfiguration;
    }


    public string GetConnectionString()
    {
        return _configuration["repository:ConnectionString"]!;
    }
}

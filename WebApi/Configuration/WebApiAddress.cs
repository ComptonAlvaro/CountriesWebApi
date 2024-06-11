using Infraestructure.CountriesRequester;



namespace WebApi.Configuration;



/// <summary>
/// Una implementación para obtener la dirección del servicio API del cual se solicitarán los países.<para/><para/>
/// 
/// De este modo se puede inyectar como dependencia en al intanciar el solicitante de países.
/// </summary>
public sealed class WebApiAddress : IWebApiAddress
{
    private readonly IConfiguration _configuration;



    public WebApiAddress(IConfiguration paramConfiguration)
    {
        _configuration = paramConfiguration;
    }


    public string GetAddress()
    {
        return _configuration["CountriesExternalWebApi:Address"]!;
    }
}

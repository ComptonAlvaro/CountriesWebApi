namespace Infraestructure.CountriesRequester;



/// <summary>
/// Se define el interfaz para obtener la dirección del API al cual se solicitarán los países.<para/><para/>
/// 
/// Se define aquí, en la capa de infraestructura y no en el proyecto Shared porque quien define el interfaz es quien lo necesita,
/// y es el solicitante el que lo necesita, no la capa de aplicación o la capa de infraestructura. Por tanto se define aquí
/// y se implementará en el proyecto WebApi, que es quien sabe la dirección, que es donde se tiene el fichero de configuración.
/// </summary>
public interface IWebApiAddress
{
    public string GetAddress();
}

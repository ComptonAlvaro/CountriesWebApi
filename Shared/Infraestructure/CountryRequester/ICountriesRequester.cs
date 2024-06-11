using Shared.Primitives;



namespace Shared.Infraestructure.CountryRequester;



/// <summary>
/// Define el interfaz del solicitante de los países, el cual podrá ser un servicio API, un fichero de texto en un servidor o en local
/// o cualquier otro recurso.<para/><para/>
/// 
/// De este modo se abstrae a la capa de aplicación de la implementación se podrá cambiar de forma sencilla en caso de necesitarse.
/// </summary>
public interface ICountriesRequester
{
    /// <summary>
    /// Obtiene todos los países del recurso al que se solicita.
    /// </summary>
    /// <returns>Una lista con todos los países del recurso.<para/><para/>
    /// 
    /// Al ser de tipo CountryDTO, se hace independiente de la implementación utilizada o del formato recibido desde el recurso,
    /// por lo que quien utilice al solicitante no se verá afectado.</returns>
    public Task<List<CountryDTO>> GetAllCountriesAsync();
}

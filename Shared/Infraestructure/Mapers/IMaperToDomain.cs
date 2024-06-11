using Domain.Countries;
using Shared.Primitives;



namespace Shared.Infraestructure.Mapers;



/// <summary>
/// Un mapeador para covertir diferentes tipos de datos a entidades del dominio.<para/><para/>
/// 
/// Esto es útil porque a nivel general de aplicación, la comunicación se hace mediante las clases DTO, pero el dominio está aislado
/// y solo conoce sus tipos, por lo que quien utilice las entidades de dominio seguramente necesitará la conversión.
/// </summary>
public interface IMaperToDomain
{
    /// <summary>
    /// Convierte el tipo CountryDTO a Country de dominio.
    /// </summary>
    /// <param name="paramCoutry"></param>
    /// <returns></returns>
    public Country ConvertTo(CountryDTO paramCoutry);



    /// <summary>
    /// Convierte el una lista de tipo CoutryDTO a una lista de Country de dominio.
    /// </summary>
    /// <param name="paramCoutries"></param>
    /// <returns></returns>
    public List<Country> ConvertTo(IEnumerable<CountryDTO> paramCoutries);
}

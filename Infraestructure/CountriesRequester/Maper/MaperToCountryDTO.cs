using Infraestructure.CountriesRequester.Primitives;
using Shared.Primitives;



namespace Infraestructure.CountriesRequester.Maper;



/// <summary>
/// Clase que convierte diferentes tipos al tipo CountryDTO, definido en el proyecto Shared.<para/><para/>
/// 
/// Se define aquí el mapeador y no en el proyecto Shared porque es un mapeador que solo será utilizado por el silicitante
/// de ficheros <seealso cref="CountriesRequesterRestCountries"/>. Esto se debe a que el solicitante utiliza el tipo
/// <seealso cref="CountryRestCountries"/> para convertir el fichero json recibido a un objeto, y la estructura del objeto viene
/// condicionado por la estructura del fichero json. Como diferentes solicitantes podrán recibir un fichero json con diferentes
/// estructuras, este mapeador solo será utilizado por el solicitante <seealso cref="CountriesRequesterRestCountries"/>.
/// </summary>
public static class MaperToCountryDTO
{
    /// <summary>
    /// Convierte el tipo <seealso cref="CountryRestCountries"/> al tipo CountryDTO definido en el proyecto Shared.
    /// </summary>
    /// <param name="paramCountry"></param>
    /// <returns></returns>
    public static CountryDTO ConvertTo(CountryRestCountries paramCountry)
    {
        return new CountryDTO(paramCountry.NameDetails.Official, paramCountry.Population);
    }



    public static List<CountryDTO> ConvertTo(IEnumerable<CountryRestCountries> paramCountries)
    {
        List<CountryDTO> countries = [];

        foreach(CountryRestCountries iteratorCountry in paramCountries)
        {
            countries.Add(ConvertTo(iteratorCountry));
        }


        return countries;
    }
}

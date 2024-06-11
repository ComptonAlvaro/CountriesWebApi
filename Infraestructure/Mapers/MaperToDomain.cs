using Domain.Countries;
using Shared.Primitives;
using Shared.Infraestructure.Mapers;



namespace Infraestructure.Mapers;



public class MaperToDomain : IMaperToDomain
{
    public Country ConvertTo(CountryDTO paramCoutry)
    {
        return new Country(paramCoutry.Name, paramCoutry.Population);
    }


    public List<Country> ConvertTo(IEnumerable<CountryDTO> paramCountries)
    {
        List<Country> countries = [];

        foreach(CountryDTO iteratorCountry in paramCountries)
        {
            countries.Add(ConvertTo(iteratorCountry));
        }


        return countries;
    }
}

using Infraestructure.CountriesRequester.Maper;
using Infraestructure.CountriesRequester.Primitives;
using Shared.Infraestructure.CountryRequester;
using Shared.Primitives;
using System.Text.Json;



namespace Application.Tests.Mocks;



/// <summary>
/// Un requester que devuelve todos los países a partir del fichero guardado desde el API rest de RestCountries.com.
/// </summary>
internal class CountriesRequester250CountriesFromJasonMock : ICountriesRequester
{
    public async Task<List<CountryDTO>> GetAllCountriesAsync()
    {
        string applicationFolder = AppDomain.CurrentDomain.BaseDirectory;

        string jsonPath = Path.Combine(applicationFolder, "Resources", "CountriesOriginales250.txt");

        string json = File.ReadAllText(jsonPath);

        List<CountryRestCountries>? countries = JsonSerializer.Deserialize<List<CountryRestCountries>>(json);

        return MaperToCountryDTO.ConvertTo(countries);
    }
}

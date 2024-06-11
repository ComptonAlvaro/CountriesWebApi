using Shared.Infraestructure.CountryRequester;
using System.Text.Json;
using Infraestructure.CountriesRequester.Primitives;
using Infraestructure.CountriesRequester.Maper;
using Shared.Primitives;
using Shared.Infraestructure.CountryRequester.Exceptions;



namespace Infraestructure.CountriesRequester;



/// <summary>
/// El solicitante de países para el API RestCountries.
/// </summary>
public sealed class CountriesRequesterRestCountries : ICountriesRequester
{
    private readonly HttpClient _httpClient;
    private readonly string _webApiAddress;


    public CountriesRequesterRestCountries(IWebApiAddress paramRequesterConfiguration, IHttpClientFactory paramHttpClientFactory)
    {
        _httpClient = paramHttpClientFactory.CreateClient();
        _httpClient.Timeout = new TimeSpan(0, 0, 60);
        _webApiAddress = paramRequesterConfiguration.GetAddress();
    }



    public async Task<List<CountryDTO>> GetAllCountriesAsync()
    {
        try
        {
            string json = await _httpClient.GetStringAsync(_webApiAddress);


            List<CountryRestCountries>? countries = JsonSerializer.Deserialize<List<CountryRestCountries>>(json);


            return MaperToCountryDTO.ConvertTo(countries);
        }
        catch (HttpRequestException ex)
        {
            throw new ResourceNotAvailableException("No se puede comunicar con el recursos al que se solicitan los países.", ex);
        }
    }
}

using Infraestructure.CountriesRequester.Maper;
using Infraestructure.CountriesRequester.Primitives;
using Infraestructure.Mapers;
using Shared.Primitives;
using System.Text.Json;
using Domain.Countries;



namespace Infraestructure.Tests;



public class MaperToDomainTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LoadAllCountries()
    {
        try
        {
            // Obtener la ruta de la carpeta de la aplicaci�n
            string carpetaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            // Combinar la ruta de la carpeta de la aplicaci�n con la subcarpeta y el nombre del archivo
            string jsonPath = Path.Combine(carpetaAplicacion, "Resources", "CountriesOriginales.txt");

            string json = File.ReadAllText(jsonPath);

            List<CountryRestCountries>? countries = JsonSerializer.Deserialize<List<CountryRestCountries>>(json);

            List<CountryDTO> countriesResult = MaperToCountryDTO.ConvertTo(countries);

            MaperToDomain domainMapper = new MaperToDomain();
            List<Country> domainCountriesFromJason = domainMapper.ConvertTo(countriesResult);

            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debi� producir ninguna excepci�n. {ex.Message}");
        }
    }
}
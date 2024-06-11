using Infraestructure.CountriesRequester.Maper;
using Infraestructure.CountriesRequester.Primitives;
using Shared.Primitives;
using System.Text.Json;



namespace Infraestructure.Tests;



public class JasonACountryRestCountriesTests
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
            // Obtener la ruta de la carpeta de la aplicación
            string carpetaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            // Combinar la ruta de la carpeta de la aplicación con la subcarpeta y el nombre del archivo
            string jsonPath = Path.Combine(carpetaAplicacion, "Resources", "CountriesOriginales.txt");

            string json = File.ReadAllText(jsonPath);

            List<CountryRestCountries>? countries = JsonSerializer.Deserialize<List<CountryRestCountries>>(json);

            List<CountryDTO> countriesResult = MaperToCountryDTO.ConvertTo(countries);

            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }
}
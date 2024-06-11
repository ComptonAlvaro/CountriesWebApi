using Infraestructure.Repositories.Interfaces;
using Infraestructure.Tests.Mocks;
using Domain.Countries;
using Infraestructure.Repositories.Queries;
using Shared.Primitives;
using Infraestructure.Mapers;
using Shared.Infraestructure.Repositories.Queries;



namespace Infraestructure.Tests;



public class CountriesRepositoryQueryEntityCore8SqliteTests
{
    IConnectionString _connectionString;
    ICountriesQueryRepository _countriesQuieryRepository;



    [SetUp]
    public void Setup()
    {
        _countriesQuieryRepository = new CountriesRepositoryQueryEntityCore8Sqlite(_connectionString);
    }


    [OneTimeSetUp]
    public void InitializeSingletonResources()
    {
        _connectionString = new ConnectionString250Countries();
    }





    [Test]
    public async Task Get_All_Countries_Then_Get_250_Countries()
    {
        try
        {
            //Se compruban el resultado
            List<CountryDTO> countries = await _countriesQuieryRepository.GetAllCountriesAsync().ConfigureAwait(false);


            Assert.That(countries.Count, Is.EqualTo(250));



            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }
}
using Infraestructure.Repositories.Interfaces;
using Application.Tests.Mocks;
using Infraestructure.Repositories.Commands;
using Infraestructure.Repositories.Queries;
using Shared.Infraestructure.Mapers;
using Infraestructure.Mapers;
using Shared.Infraestructure.CountryRequester;
using Application.Countries.UpdateAllCountries;
using Application.Countries.GetAllCountries;
using Shared.Infraestructure.Repositories.Commands;
using Shared.Infraestructure.Repositories.Queries;



namespace Application.Tests;



public class GetllCountriesQueryHandlerTests
{
    IConnectionString _connectionString;
    ICountriesCommandUnitOfWork _unitOfWwork;
    ICountriesQueryRepository _countriesRepositoryQueries;
    IMaperToDomain _domainMapper;
    ICountriesRequester _countriesRequester250Countries;



    [SetUp]
    public async Task Setup()
    {
        _unitOfWwork = new CountriesUnitOfWorkCommandEntityCore8SqlLite(_connectionString);
        _countriesRepositoryQueries = new CountriesRepositoryQueryEntityCore8Sqlite(_connectionString);


        //Se vacía la base de datos para partir de un estado incial conocido.
        await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);
        _unitOfWwork.CountriesRepository.RemoveAllCountries();
        await _unitOfWwork.CommitAsync().ConfigureAwait(false);
    }


    [OneTimeSetUp]
    public void InitializeSingletonResources()
    {
        _domainMapper = new MaperToDomain();
        _countriesRequester250Countries = new CountriesRequester250CountriesFromJasonMock();
        _connectionString = new ConnectionString();
    }



    [Test]
    public async Task Get_250_Countries_Then_CountriesInDataBase()
    {
        try
        {
            //Se agregan los países a la base de datos
            UpdateAllCountriesQueryHandler handler = new UpdateAllCountriesQueryHandler(_countriesRequester250Countries, _unitOfWwork, _domainMapper);
            await handler.Handle(null, new CancellationTokenSource().Token);



            GetllCountriesQueryHandler getCountryHandler = new GetllCountriesQueryHandler(_countriesRepositoryQueries);
            string jsonFromLocalDatabase = await getCountryHandler.Handle(null, new CancellationTokenSource().Token);


            Assert.That(jsonFromLocalDatabase, Is.Not.Empty);



            Assert.Pass();
        }
        catch (SuccessException) { }
        catch(Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }
}
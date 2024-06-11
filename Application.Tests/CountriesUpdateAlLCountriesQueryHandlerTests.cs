using Infraestructure.Repositories.Interfaces;
using Application.Tests.Mocks;
using Infraestructure.Repositories.Commands;
using Infraestructure.Mapers;
using Shared.Infraestructure.Mapers;
using Shared.Infraestructure.CountryRequester;
using Application.Countries.UpdateAllCountries;
using Domain.Countries;
using Shared.Infraestructure.Repositories.Commands;



namespace Application.Tests;



public class UpdateAlLCountriesQueryHandlerTests
{
    IConnectionString _connectionString;
    ICountriesCommandUnitOfWork _unitOfWwork;
    IMaperToDomain _domainMapper;
    ICountriesRequester _countriesRequester250Countries;



    [SetUp]
    public async Task Setup()
    {
        _connectionString = new ConnectionString();
        _unitOfWwork = new CountriesUnitOfWorkCommandEntityCore8SqlLite(_connectionString);
        


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
    }



    [Test]
    public async Task Add_250_Countries_From_Json_File_Then_CountriesInDataBase()
    {
        try
        {
            //Se ejecuta el test
            UpdateAllCountriesQueryHandler handler = new UpdateAllCountriesQueryHandler(_countriesRequester250Countries, _unitOfWwork, _domainMapper);
            await handler.Handle(null, new CancellationTokenSource().Token);


            //Se comprueba que se han guardado los países en la base de datos
            List<Country> finalCoutries = await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);
            Assert.That(finalCoutries.Count, Is.EqualTo(250));



            Assert.Pass();
        }
        catch (SuccessException) { }
        catch(Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }
}
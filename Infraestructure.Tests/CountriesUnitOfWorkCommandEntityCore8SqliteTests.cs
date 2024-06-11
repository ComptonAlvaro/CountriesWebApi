using Infraestructure.Repositories.Commands;
using Infraestructure.Repositories.Interfaces;
using Infraestructure.Tests.Mocks;
using Shared.Infraestructure.Repositories.Exceptions;
using Domain.Countries;
using Shared.Infraestructure.Repositories.Commands;




namespace Infraestructure.Tests;



public class CountriesUnitOfWorkCommandEntityCore8SqliteTests
{
    IConnectionString _connectionString;
    IConnectionString _connectionString250Countries;
    IConnectionString _connectionString250CountriesInvalidPath;
    ICountriesCommandUnitOfWork _unitOfWwork;



    [SetUp]
    public async Task Setup()
    {
        _connectionString = new ConnectionString();
        _connectionString250Countries = new ConnectionString250Countries();
        _connectionString250CountriesInvalidPath = new ConnectionString250CountriesInvalidPath();
        _unitOfWwork = new CountriesUnitOfWorkCommandEntityCore8SqlLite(_connectionString);


        //Se vac�a la base de datos para partir de un estado incial conocido.
        await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);
        _unitOfWwork.CountriesRepository.RemoveAllCountries();
        await _unitOfWwork.CommitAsync().ConfigureAwait(false);
    }





    [Test]
    public async Task Add_One_Country_Then_Save_Country()
    {
        try
        {
            //Se agrega el pa�s
            Country newCountry = new Country("Country01", 100);
            _unitOfWwork.CountriesRepository.Add(newCountry);
            await _unitOfWwork.CommitAsync().ConfigureAwait(false);



            //Se compruban el resultado
            List<Country> countries = await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);

            Assert.That(countries.Count, Is.EqualTo(1));
            Country countryResult = countries.First();
            Assert.That(string.CompareOrdinal(countryResult.Name, "Country01"), Is.EqualTo(0));
            Assert.That(countryResult.Population, Is.EqualTo(100));



            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debi� producir ninguna excepci�n. {ex.Message}");
        }
    }




    [Test]
    public async Task Add_One_Country_To_Invalid_Path_Then_Exception()
    {
        try
        {
            //Se crea un unit of work con la ruta incorrecta de la base de datos.
            CountriesUnitOfWorkCommandEntityCore8SqlLite _incorrectUnitOfWork = new CountriesUnitOfWorkCommandEntityCore8SqlLite(_connectionString250CountriesInvalidPath);


            //Se agrega el pa�s
            Country newCountry = new Country("Country01", 100);
            _incorrectUnitOfWork.CountriesRepository.Add(newCountry);
            await _incorrectUnitOfWork.CommitAsync().ConfigureAwait(false);



            Assert.Pass();
        }
        catch (DataBaseNotAvailableException ex) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debi� producir ninguna excepci�n. {ex.Message}");
        }
    }





    [Test]
    public async Task Delete_All_Countries_Then_No_Countries_In_DataBase()
    {
        try
        {
            //Se agrega el pa�s
            Country newCountry = new Country("Country01", 100);
            _unitOfWwork.CountriesRepository.Add(newCountry);
            await _unitOfWwork.CommitAsync().ConfigureAwait(false);


            //Se asegura que hay pa�ses para borrar
            List<Country> countries = await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);
            Assert.That(countries.Count, Is.EqualTo(1));


            //Se realiza el test, borrar todos los pa�ses
            _unitOfWwork.CountriesRepository.RemoveRange(countries);
            await _unitOfWwork.CommitAsync().ConfigureAwait(false);


            //Se comprueba que se han borrado todos los pa�ses
            List<Country> countriesResult = await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);
            Assert.That(countriesResult, Is.Empty);


            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debi� producir ninguna excepci�n. {ex.Message}");
        }
    }




    [Test]
    public async Task Get_All_Countries_No_Countries_Then_Empty_List()
    {
        try
        {
            List<Country> countries = await _unitOfWwork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);


            Assert.That(countries, Is.Empty);


            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debi� producir ninguna excepci�n. {ex.Message}");
        }
    }
}
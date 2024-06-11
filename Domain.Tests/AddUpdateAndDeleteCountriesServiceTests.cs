using Domain.Countries.Services;
using Domain.Countries;



namespace Domain.Tests;



public class AddUpdateAndDeleteCountriesServiceTests
{
    [SetUp]
    public void Setup()
    {
    }




    [Test]
    public void No_Actual_Countries_No_New_Countries_Then_Empty_Results()
    {
        try
        {
            List<Country> actualCountries = [];
            List<Country> newCountries = [];

            (List<Country> addedCountriesResult, List<Country> deletedCountriesResult) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);


            Assert.That(addedCountriesResult, Is.Empty);
            Assert.That(deletedCountriesResult, Is.Empty);


            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }




    [Test]
    public void One_Actual_Countries_No_New_Countries_Then_Empty_Results()
    {
        try
        {
            List<Country> actualCountries = [];
            Country actualCountry = new Country("Actual Country", 100);
            actualCountries.Add(actualCountry);


            List<Country> newCountries = [];


            (List<Country> addedCountriesResult, List<Country> deletedCountriesResult) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);



            Assert.That(addedCountriesResult, Is.Empty);

            Assert.That(deletedCountriesResult.Count, Is.EqualTo(1));
            Country deletedCountryResult = deletedCountriesResult[0];
            Assert.That(Is.ReferenceEquals(deletedCountryResult, actualCountry));


            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }




    [Test]
    public void No_Actual_Countries_One_New_Countries_Then_Empty_Add_One_Country()
    {
        try
        {
            List<Country> actualCountries = [];
            

            List<Country> newCountries = [];
            Country newCountry = new Country("New Country", 100);
            newCountries.Add(newCountry);



            (List<Country> addedCountriesResult, List<Country> deletedCountriesResult) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);



            Assert.That(addedCountriesResult.Count, Is.EqualTo(1));
            Country addedCountryResult = addedCountriesResult[0];
            Assert.That(Is.ReferenceEquals(addedCountryResult, newCountry));


            Assert.That(deletedCountriesResult, Is.Empty);



            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }





    [Test]
    public void One_Actual_Countries_One_New_Countries_DifferentCountries_Then_Update()
    {
        try
        {
            List<Country> actualCountries = [];
            Country actualCountry = new Country("Actual Country", 100);
            actualCountries.Add(actualCountry);


            List<Country> newCountries = [];
            Country newCountry = new Country("New Country", 200);
            newCountries.Add(newCountry);



            (List<Country> addedCountriesResult, List<Country> deletedCountriesResult) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);



            Assert.That(addedCountriesResult.Count, Is.EqualTo(1));
            Country addedCountryResult = addedCountriesResult[0];
            Assert.That(Is.ReferenceEquals(addedCountryResult, newCountry));


            Assert.That(deletedCountriesResult.Count, Is.EqualTo(1));
            Country deletedCountryResult = deletedCountriesResult[0];
            Assert.That(Is.ReferenceEquals(deletedCountryResult, actualCountry));



            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }






    [Test]
    public void One_Actual_Countries_One_New_Countries_Same_Country_Different_Population_Then_Update_Population()
    {
        try
        {
            List<Country> actualCountries = [];
            Country actualCountry = new Country("Country 01", 100);
            actualCountries.Add(actualCountry);


            List<Country> newCountries = [];
            Country newCountry = new Country("Country 01", 200);
            newCountries.Add(newCountry);



            (List<Country> addedCountriesResult, List<Country> deletedCountriesResult) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);



            Assert.That(addedCountriesResult.Count, Is.EqualTo(0));

            Assert.That(deletedCountriesResult.Count, Is.EqualTo(0));

            Assert.That(actualCountry.Population, Is.EqualTo(200));


            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }





    [Test]
    public void Two_Actual_Countries_Two_New_Countries_One_In_Common_With_Different_Population_Then_Add_One_Update_One_And_Delete_One()
    {
        try
        {
            List<Country> actualCountries = [];
            Country actualCountry01 = new Country("Actual Country 01", 100);
            Country actualCountry02 = new Country("Actual Country 02", 200);
            actualCountries.Add(actualCountry01);
            actualCountries.Add(actualCountry02);


            List<Country> newCountries = [];
            Country newCountry01 = new Country("Actual Country 02", 300);
            Country newCountry02 = new Country("New Country 03", 400);
            newCountries.Add(newCountry01);
            newCountries.Add(newCountry02);



            (List<Country> addedCountriesResult, List<Country> deletedCountriesResult) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);



            Assert.That(addedCountriesResult.Count, Is.EqualTo(1));
            Country addedCountryResult = addedCountriesResult.First();
            Assert.That(Is.ReferenceEquals(addedCountryResult, newCountry02));

            Assert.That(deletedCountriesResult.Count, Is.EqualTo(1));
            Country deletedCountryResult = deletedCountriesResult.First();
            Assert.That(Is.ReferenceEquals(deletedCountryResult, actualCountry01));

            Assert.That(actualCountry02.Population, Is.EqualTo(300));


            Assert.Pass();
        }
        catch (SuccessException) { }
        catch (Exception ex)
        {
            Assert.Fail($"No se debió producir ninguna excepción. {ex.Message}");
        }
    }
}
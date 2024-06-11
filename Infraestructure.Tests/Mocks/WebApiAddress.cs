using Infraestructure.CountriesRequester;



namespace Infraestructure.Tests.Mocks;



internal class WebApiAddress : IWebApiAddress
{
    public string GetAddress()
    {
        return "https://restcountries.com/v3.1/all";
    }
}

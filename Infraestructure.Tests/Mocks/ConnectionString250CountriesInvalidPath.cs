using Infraestructure.Repositories.Interfaces;



namespace Infraestructure.Tests.Mocks;



internal class ConnectionString250CountriesInvalidPath : IConnectionString
{
    public string GetConnectionString()
    {
        string applicationFolder = AppDomain.CurrentDomain.BaseDirectory;

        string pathToDataBase = Path.Combine(applicationFolder, "Resources", "250Countries0.sqlite");

        return $"Data Source={pathToDataBase}";
    }
}

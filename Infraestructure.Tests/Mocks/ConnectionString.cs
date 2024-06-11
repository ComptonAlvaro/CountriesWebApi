using Infraestructure.Repositories.Interfaces;



namespace Infraestructure.Tests.Mocks;



internal class ConnectionString : IConnectionString
{
    public string GetConnectionString()
    {
        string applicationFolder = AppDomain.CurrentDomain.BaseDirectory;

        string pathToDataBase = Path.Combine(applicationFolder, "Resources", "Countries.sqlite");

        return $"Data Source={pathToDataBase}";
    }
}

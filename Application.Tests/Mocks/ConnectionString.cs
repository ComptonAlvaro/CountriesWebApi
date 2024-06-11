using Infraestructure.Repositories.Interfaces;

namespace Application.Tests.Mocks;



internal class ConnectionString : IConnectionString
{
    public string GetConnectionString()
    {
        string applicationFolder = AppDomain.CurrentDomain.BaseDirectory;

        //"Data Source=d:/Countries.sqlite"
        string pathToDataBase = Path.Combine(applicationFolder, "Resources", "Countries.sqlite");

        return $"Data Source={pathToDataBase}";
    }
}

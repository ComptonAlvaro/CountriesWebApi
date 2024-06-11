namespace Shared.Infraestructure.Repositories.Commands;



/// <summary>
/// Define la Unit of Work de repositorio de comandos.<para/><para/>
/// 
/// 
/// </summary>
public interface ICountriesCommandUnitOfWork
{
    public ICountriesCommandRepository CountriesRepository { get; }


    Task<int> CommitAsync();
}

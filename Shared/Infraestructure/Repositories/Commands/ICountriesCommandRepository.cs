using Domain.Countries;



namespace Shared.Infraestructure.Repositories.Commands;



public interface ICountriesCommandRepository : IRepository<Country>
{
    /// <summary>
    /// Se agregan todos los países al contexto desde la base de datos.
    /// </summary>
    /// <returns></returns>
    public Task<List<Country>> GetAllCountriesAsync();


    /// <summary>
    /// Quita todas las entidades Country del contexto, en espera a confirmar los cambios cuando se confirmen los cambios.
    /// </summary>
    /// <returns></returns>
    public void RemoveAllCountries();
}

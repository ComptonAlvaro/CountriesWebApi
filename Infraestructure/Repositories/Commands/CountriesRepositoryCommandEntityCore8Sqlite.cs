using Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Repositories.Exceptions;
using Shared.Infraestructure.Repositories.Commands;



namespace Infraestructure.Repositories.Commands;



internal sealed class CountriesRepositoryCommandEntityCore8Sqlite : Repository<Country>, ICountriesCommandRepository
{
    #region variables de clase
    private readonly CountriesDbContextCommandEntityCore8Sqlite _context;
    #endregion variables de clase



    #region constructores
    //NOTA: aquí se pasa por parámetro el contexto que se tiene que utilizar, no se crea aquí.
    //Y el contexto se crea en el unit of work, ya que si el unit of work utiliza varios repositorios, se podrá pasar
    //el mismo contexto y todas las entidades estarán relacionadas.
    public CountriesRepositoryCommandEntityCore8Sqlite(CountriesDbContextCommandEntityCore8Sqlite paramContext) : base(paramContext)
    {
        _context = paramContext;
    }
    #endregion constructores






    public async Task<List<Country>> GetAllCountriesAsync()
    {
        try
        {
            return await _context.Countries
            .ToListAsync()
            .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw RepositoryExceptionHandler.GetException(ex);
        }
    }


    public void RemoveAllCountries()
    {
        try
        {
            _context.Countries.Local.Clear();
        }
        catch (Exception ex)
        {
            throw RepositoryExceptionHandler.GetException(ex);
        }
    }
}

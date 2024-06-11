using Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Primitives;
using Infraestructure.Repositories.Exceptions;
using Shared.Infraestructure.Repositories.Queries;



namespace Infraestructure.Repositories.Queries;



public class CountriesRepositoryQueryEntityCore8Sqlite : ICountriesQueryRepository
{
    #region variables
    private readonly CountriesDbContextQueryEntityCore8Sqlite _context;
    #endregion variables



    #region constructores
    public CountriesRepositoryQueryEntityCore8Sqlite(IConnectionString paramConnectionString)
    {
        //La configuarción que tendrá el dbContext
        DbContextOptionsBuilder<CountriesDbContextQueryEntityCore8Sqlite> miBulider = new DbContextOptionsBuilder<CountriesDbContextQueryEntityCore8Sqlite>();

        miBulider.UseSqlite(paramConnectionString.GetConnectionString());

        _context = new CountriesDbContextQueryEntityCore8Sqlite(miBulider.Options);
    }
    #endregion constructores





    public async Task<List<CountryDTO>> GetAllCountriesAsync()
    {
        try
        {
            return await _context.Countries
            .ToListAsync()
            .ConfigureAwait(false);
        }
        catch(Exception ex)
        {
            throw RepositoryExceptionHandler.GetException(ex);
        }
    }
}

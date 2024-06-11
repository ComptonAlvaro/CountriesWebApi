using Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Repositories.Exceptions;
using Shared.Infraestructure.Repositories.Commands;



namespace Infraestructure.Repositories.Commands;



public sealed class CountriesUnitOfWorkCommandEntityCore8SqlLite : ICountriesCommandUnitOfWork
{
    public ICountriesCommandRepository CountriesRepository { get; private set; }
    private readonly CountriesDbContextCommandEntityCore8Sqlite _context;



    public CountriesUnitOfWorkCommandEntityCore8SqlLite(IConnectionString paramConnectionString)
    {
        DbContextOptionsBuilder<CountriesDbContextCommandEntityCore8Sqlite> miBulider = new DbContextOptionsBuilder<CountriesDbContextCommandEntityCore8Sqlite>();
        miBulider.UseSqlite(paramConnectionString.GetConnectionString());
        _context = new CountriesDbContextCommandEntityCore8Sqlite(miBulider.Options);
        _context.ChangeTracker.LazyLoadingEnabled = false;



        CountriesRepository = new CountriesRepositoryCommandEntityCore8Sqlite(_context);
    }




    public async Task<int> CommitAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw RepositoryExceptionHandler.GetException(ex);
        }
    }
}

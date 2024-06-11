using Infraestructure.Repositories.Queries.Configurations;
using Microsoft.EntityFrameworkCore;
using Shared.Primitives;



namespace Infraestructure.Repositories.Queries;



public sealed class CountriesDbContextQueryEntityCore8Sqlite : DbContext
{
    #region constructores
    private CountriesDbContextQueryEntityCore8Sqlite() { }


    public CountriesDbContextQueryEntityCore8Sqlite(DbContextOptions<CountriesDbContextQueryEntityCore8Sqlite> paramOptions) : base(paramOptions) { }
    #endregion constructores



    #region DbSet
    //Solo se tienen DbSets de entidades raíz.
    internal DbSet<CountryDTO> Countries { get; set; }
    #endregion DbSet



    #region Configuración
    protected override void OnModelCreating(ModelBuilder paramModelBuilder)
    {
        paramModelBuilder.ApplyConfiguration(new ConutriesConfiguration());
    }
    #endregion Configuración
}

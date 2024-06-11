using Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Repositories.Commands.Configurations;



namespace Infraestructure.Repositories.Commands;



public class CountriesDbContextCommandEntityCore8Sqlite : DbContext
{
    private CountriesDbContextCommandEntityCore8Sqlite() { }

    /// <summary>
    /// Instancia el contexto con las opciones del contexto indicadas.
    /// </summary>
    /// <param name="paramOptions">Las opciones del contexto.</param>
    /// <remarks>Será el consumidor del contexto el que determine las opciones y pasará la instacia por
    /// parámetros. El consumidor será una clase que implemente el interfaz del repositorio definido en la capa
    /// de aplicación.
    /// @#ESTUDIAR: ¿no sería mejor instanciar las opciones aquí y por parámetros pasar solo la cadena de conexión
    /// que necesitará?</remarks>
    public CountriesDbContextCommandEntityCore8Sqlite(DbContextOptions<CountriesDbContextCommandEntityCore8Sqlite> paramOptions) : base(paramOptions) { }




    internal DbSet<Country> Countries { get; set; }




    #region Configuración
    protected override void OnModelCreating(ModelBuilder paramModelBuilder)
    {
        paramModelBuilder.ApplyConfiguration(new CountriesConfiguration());
    }
    #endregion Configuración
}

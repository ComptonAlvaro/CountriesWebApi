using Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Repositories.Commands.Configurations;



internal sealed class CountriesConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> paramCountryConfiguration)
    {
        paramCountryConfiguration.ToTable("Countries");

        paramCountryConfiguration.HasKey(o => o.Name);
        //Se indica que el ID lo asingará la base de datos al agregar la entidad.
        paramCountryConfiguration.Property<string>(o => o.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar(200)")
            .IsRequired();


        paramCountryConfiguration.Property<int>(o => o.Population)
            .HasColumnName("Population")
            .HasColumnType("int")
            .IsRequired();
    }
}

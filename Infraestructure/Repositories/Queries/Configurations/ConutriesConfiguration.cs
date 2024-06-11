using Shared.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Countries;



namespace Infraestructure.Repositories.Queries.Configurations;


public sealed class ConutriesConfiguration : IEntityTypeConfiguration<CountryDTO>
{
    public void Configure(EntityTypeBuilder<CountryDTO> paramCountryConfiguration)
    {
        paramCountryConfiguration.ToTable("Countries");


        paramCountryConfiguration.HasKey(o => o.Name);


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

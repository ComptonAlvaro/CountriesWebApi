using Shared.Primitives;



namespace Shared.Infraestructure.Repositories.Queries;



public interface ICountriesQueryRepository
{
    public Task<List<CountryDTO>> GetAllCountriesAsync();
}

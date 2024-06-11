using MediatR;



namespace Application.Countries.UpdateAllCountries;



public record UpdateAllCountriesQuery() : IRequest<Unit>;

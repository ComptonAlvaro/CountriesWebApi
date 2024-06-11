using MediatR;



namespace Application.Countries.GetAllCountries;



public record GetAllCountriesQuery() : IRequest<string>;

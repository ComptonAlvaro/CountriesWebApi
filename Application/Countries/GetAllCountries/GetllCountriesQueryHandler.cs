using MediatR;
using Shared.Infraestructure.Repositories.Queries;
using Shared.Primitives;
using System.Text.Encodings.Web;
using System.Text.Json;



namespace Application.Countries.GetAllCountries;



public sealed class GetllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, string>
{
    private readonly ICountriesQueryRepository _countriesQueryRepository;



    public GetllCountriesQueryHandler(ICountriesQueryRepository paramCountriesRepository)
    {
        _countriesQueryRepository = paramCountriesRepository;
    }

    public async Task<string> Handle(GetAllCountriesQuery paramCommand, CancellationToken cancellationToken)
    {
        List<CountryDTO> allCountries = await _countriesQueryRepository.GetAllCountriesAsync().ConfigureAwait(false);



        string allCountriesJson = JsonSerializer.Serialize(allCountries, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(new TextEncoderSettings(System.Text.Unicode.UnicodeRanges.All)),
        });


        return allCountriesJson;
    }
}

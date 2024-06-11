using MediatR;
using Shared.Infraestructure.CountryRequester;
using Shared.Infraestructure.Mapers;
using Domain.Countries;
using Domain.Countries.Services;
using Shared.Infraestructure.Repositories.Commands;



namespace Application.Countries.UpdateAllCountries;



public sealed class UpdateAllCountriesQueryHandler : IRequestHandler<UpdateAllCountriesQuery, Unit>
{
    private readonly ICountriesCommandUnitOfWork _countriesUnitOfWork;
    private readonly ICountriesRequester _countriesRequester;
    private readonly IMaperToDomain _maperToDomain;



    public UpdateAllCountriesQueryHandler(ICountriesRequester paramCoutriesRequester,
        ICountriesCommandUnitOfWork paramCountryRepository,
        IMaperToDomain paramMaperToDomain)
    {
        _countriesUnitOfWork = paramCountryRepository;
        _countriesRequester = paramCoutriesRequester;
        _maperToDomain = paramMaperToDomain;
    }




    public async Task<Unit> Handle(UpdateAllCountriesQuery paramCommand, CancellationToken cancellationToken)
    {
        //Se obtienen todos los países del API externo.
        List<Country> newCountries = _maperToDomain.ConvertTo(await _countriesRequester.GetAllCountriesAsync().ConfigureAwait(false));


        //Se actualiza la base de datos.
        //Se borrarán todos los paises actuales de la tabla y se agregarán los que se reciben desde el API.
        //Esto supone actualizar la base de datos
        List<Country> actualCountries = await _countriesUnitOfWork.CountriesRepository.GetAllCountriesAsync().ConfigureAwait(false);


        //Se determinan los países que se tienen que agregar y borrar, para persistir los datos de una sola vez.
        //Se podría pensar en directamente borrar todos los de la tabla de la base de datos local y agregar todos los países
        //recibidos, pero podría hacer que el proceso fallase después de borrarlos y antes de agregar los nuevos, por lo que se
        //considera que mejor hacer todo o nada.
        (List<Country> countriesToAdd, List<Country> countriesToDelete) = AddUpdateAndDeleteCountriesService.AddUpdateAndDeleteCountries(actualCountries, newCountries);


        _countriesUnitOfWork.CountriesRepository.RemoveRange(countriesToDelete);
        _countriesUnitOfWork.CountriesRepository.AddRange(countriesToAdd);

        await _countriesUnitOfWork.CommitAsync().ConfigureAwait(false);


        return Unit.Value;
    }
}

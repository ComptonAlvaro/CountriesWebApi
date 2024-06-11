using Application.Countries.UpdateAllCountries;
using Application.Countries.GetAllCountries;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace WebApi.Controllers;



[ApiController]
[Route("/api/v1/data/country")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;
    private readonly ISender _mediator;



    public CountriesController(ISender paramMediator, ILogger<CountriesController> paramLogger)
    {
        _logger = paramLogger;
        _mediator = paramMediator;
    }



    [HttpPost]
    public async Task<Unit> UpdateAllCountries()
    {
        return await _mediator.Send(new UpdateAllCountriesQuery());
    }




    [HttpGet]
    public async Task<string> GetAllCountries()
    {
        return await _mediator.Send(new GetAllCountriesQuery());
    }
}

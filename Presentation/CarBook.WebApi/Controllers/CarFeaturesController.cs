using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarPricingWithCarList(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("ChangeCarFeatureAvailableToFalse")]
        public async Task<IActionResult> ChangeCarFeatureAvailableToFalse(int id)
        {
            await _mediator.Send(new ChangeCarFeatureAvailableToFalseCommand(id));
            return Ok("Güncelleme yapıldı.");
        }

        [HttpGet("ChangeCarFeatureAvailableToTrue")]
        public async Task<IActionResult> ChangeCarFeatureAvailableToTrue(int id)
        {
            await _mediator.Send(new ChangeCarFeatureAvailableToTrueCommand(id));
            return Ok("Güncelleme yapıldı.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme yapıldı.");
        }
    }
}

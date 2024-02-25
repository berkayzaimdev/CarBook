using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RegisterController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Login(CreateAppUserCommand command)
		{
			await _mediator.Send(command);
			return Ok("Kullanıcı başarıyla oluşturuldu");
		}
	}
}

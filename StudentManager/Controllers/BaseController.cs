using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace StudentManager.API.Controllers
{
	/// <summary>
	/// Base controller
	/// </summary>
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class BaseController : ControllerBase
	{
		private IMediator _mediator;

		/// <summary>
		/// Mediator to encapsulate request/response and publishing interaction patterns
		/// </summary>
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}

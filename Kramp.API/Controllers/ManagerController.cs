using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Create-Manager")]
        public async Task<ActionResult<ManagerInfoViewModel>> CreateManager(CreateManagerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

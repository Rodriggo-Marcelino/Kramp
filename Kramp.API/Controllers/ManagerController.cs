using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("Read")]
        public async Task<ActionResult<ManagerInfoViewModel>> Read(CreateManagerCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ManagerInfoViewModel>> Create(CreateManagerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ManagerInfoViewModel>> Update(CreateManagerCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ManagerInfoViewModel>> Delete(CreateManagerCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

using Application.GymCQ.Commands;
using Application.GymCQ.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Create")]
        public async Task<ActionResult<GymInfoViewModel>> Create(CreateGymCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("Read")]
        public async Task<ActionResult<GymInfoViewModel>> Read(CreateGymCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<GymInfoViewModel>> Update(CreateGymCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<GymInfoViewModel>> Delete(CreateGymCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

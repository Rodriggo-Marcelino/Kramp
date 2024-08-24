using Application.ProfessionalCQ.Commands;
using Application.ProfessionalCQ.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Create")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Create(CreateProfessionalCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("Read")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Read(CreateProfessionalCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Update(CreateProfessionalCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Delete(CreateProfessionalCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

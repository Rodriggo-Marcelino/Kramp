using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController(IMediator _mediator, ManagerRepository _repository, IMapper _mapper) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<UserGenericViewModel>> Create([FromBody] CreateUserGenericCommand<Manager, UserGenericViewModel> command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<UserGenericViewModel>>> GetAllManagers()
        {
            var query = new GetAllEntitiesQuery<UserGenericViewModel>();
            var managers = await _mediator.Send(query);
            return Ok(managers);
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<UserGenericViewModel>> GetManagerById(Guid Id)
        {
            var query = new GetEntityByIdQuery<UserGenericViewModel>(Id);
            var manager = await _mediator.Send(query);
            return Ok(manager);
        }

        [HttpPut("Update/{Id:guid}")]
        public async Task<ActionResult<UserGenericViewModel>> Update(Guid Id, [FromBody] UpdateEntityCommand<Manager, UserGenericViewModel> command)
        {
            command.Id = Id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult> DeleteById(Guid Id)
        {
            var command = new DeleteEntityCommand<Manager>(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

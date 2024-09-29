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
    [Route("api/managers")]
    [ApiController]
    public class ManagerController(IMediator _mediator, ManagerRepository _repository, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserGenericViewModel>> Create([FromBody] CreateUserCommand<Manager, UserGenericViewModel> command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserGenericViewModel>>> GetAllManagers()
        {
            var query = new GetAllEntitiesQueryBase<UserGenericViewModel>();
            var managers = await _mediator.Send(query);
            return Ok(managers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserGenericViewModel>> GetManagerById(Guid id)
        {
            var query = new GetEntityByIdQueryBase<UserGenericViewModel>(id);
            var manager = await _mediator.Send(query);
            return Ok(manager);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserGenericViewModel>> Update(Guid id, [FromBody] UpdateUserCommand<Manager, UserGenericViewModel> command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteById(Guid Id)
        {
            var command = new DeleteEntityCommandBase<Manager>(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

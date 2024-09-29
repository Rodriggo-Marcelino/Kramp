using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create([FromBody] CreateUserCommand<Manager, UserViewModel> command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllManagers()
        {
            var query = new GetAllEntitiesQueryBase<UserViewModel>();
            var managers = await _mediator.Send(query);
            return Ok(managers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> GetManagerById(Guid id)
        {
            var query = new GetEntityByIdQueryBase<UserViewModel>(id);
            var manager = await _mediator.Send(query);
            return Ok(manager);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> Update(Guid id, [FromBody] UpdateUserCommand<Manager, UserViewModel> command)
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

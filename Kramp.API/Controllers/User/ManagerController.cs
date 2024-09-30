using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.DTOs;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers.User
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateManager([FromBody] CreateUserDTO data)
        {
            var command = new CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>(data);
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllManagers()
        {
            var query = new GetAllEntitiesQuery<UserViewModel>();
            var managers = await _mediator.Send(query);
            return Ok(managers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> GetManagerById(Guid id)
        {
            var query = new GetEntityByIdQuery<UserViewModel>(id);
            var manager = await _mediator.Send(query);
            return Ok(manager);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> UpdateManager(Guid id, [FromBody] UpdateUserDTO dto)
        {
            var command = new UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>(id, dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteManager(Guid id)
        {
            var command = new DeleteEntityCommand<Manager>(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.DTOs.Update;
using Application.CQRS.Queries;
using Application.CQRS.ViewModels;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers.User
{
    [Route("api/members")]
    [ApiController]
    public class MemberController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateMember(CreateUserDTO data)
        {
            var command = new CreateEntityCommand<Member, CreateUserDTO, UserViewModel>(data);
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("all")]
        public async Task<ActionResult<UserViewModel>> GetAllMembers()
        {
            var query = new GetAllEntitiesQuery<UserViewModel>();
            var members = await _mediator.Send(query);
            return Ok(members);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> GetMemberById(Guid id)
        {
            var query = new GetEntityByIdQuery<UserViewModel>(id);
            var member = await _mediator.Send(query);
            return Ok(member);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> UpdateMember(Guid id, UpdateUserDTO data)
        {
            data.Id = id;
            var command = new UpdateEntityCommand<Member, UpdateUserDTO, UserViewModel>(data);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteMember(Guid id)
        {
            var command = new DeleteEntityCommand<Member>(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
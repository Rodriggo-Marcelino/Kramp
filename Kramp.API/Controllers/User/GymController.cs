using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.UsersCQRS.GymCQ.DTOs;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers.User
{
    [Route("api/gyms")]
    [ApiController]
    public class GymController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GymViewModel>> CreateGym([FromBody] CreateGymDTO data)
        {
            var command = new CreateEntityCommand<Gym, CreateGymDTO, GymViewModel>(data);
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("all")]
        public async Task<ActionResult<GymViewModel>> GetAllGyms()
        {
            var query = new GetAllEntitiesQuery<GymViewModel>();
            var gyms = await _mediator.Send(query);
            return Ok(gyms);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GymViewModel>> GetGymById(Guid id)
        {
            var query = new GetEntityByIdQuery<GymViewModel>(id);
            var gym = await _mediator.Send(query);
            return Ok(gym);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GymViewModel>> UpdateGym(Guid id, [FromBody] UpdateGymDTO data)
        {
            data.Id = id;
            var command = new UpdateEntityCommand<Gym, UpdateGymDTO, GymViewModel>(data);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<GymViewModel>> DeleteGym(Guid id)
        {
            var command = new DeleteEntityCommand<Gym>(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
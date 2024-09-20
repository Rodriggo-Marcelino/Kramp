using Application.GymCQ.Commands;
using Application.GymCQ.ViewModels;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController(IMediator _mediator, GymRepository _repository, IMapper _mapper) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<GymInfoViewModel>> Create(CreateGymCommand command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<GymInfoViewModel>> GetAllGyms()
        {
            var gyms = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GymInfoViewModel>>(gyms));
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<GymInfoViewModel>> GetGymById(Guid Id)
        {
            Gym? gym = await _repository.GetByIdAsync(Id);

            if (gym == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GymInfoViewModel>(gym));
        }

        [HttpPut("Update/{Id:guid}")]
        public async Task<ActionResult<GymInfoViewModel>> Update(Guid Id, UpdateGymCommand command)
        {
            command.Id = Id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult<GymInfoViewModel>> DeleteById(Guid Id)
        {
            //TODO: Retirar o método de delete do controller (má prática)
            await _repository.DeleteByIdAsync(Id, new CancellationToken());
            return NoContent();
        }
    }
}

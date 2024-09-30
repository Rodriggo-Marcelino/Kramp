using Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController(IMediator _mediator, ProfessionalRepository _repository, IMapper _mapper)
        : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Create(CreateProfessionalCommand command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> GetAllProfessionals()
        {
            var professionals = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProfessionalInfoViewModel>>(professionals));
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> GetProfessionalById(Guid Id)
        {
            Professional? professional = await _repository.GetByIdAsync(Id);

            if (professional == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProfessionalInfoViewModel>(professional));
        }

        [HttpPut("Update/{Id:guid}")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Update(Guid Id, UpdateProfessionalCommand command)
        {
            command.Id = Id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> DeleteById(Guid Id)
        {
            await _repository.DeleteByIdAsync(Id);
            return NoContent();
        }
    }
}
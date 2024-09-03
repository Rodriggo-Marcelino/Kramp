using Application.ProfessionalCQ.Commands;
using Application.ProfessionalCQ.ViewModels;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController(IMediator _mediator, ProfessionalRepository _repository, IMapper _mapper) : ControllerBase
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
            
            if(professional == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ProfessionalInfoViewModel>(professional));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> Update(CreateProfessionalCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult<ProfessionalInfoViewModel>> DeleteById(Guid Id)
        {
            await _repository.DeleteByIdAsync(Id, new CancellationToken());
            return NoContent();
        }
    }
}

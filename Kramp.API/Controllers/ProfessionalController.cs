using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("api/professional")]
    [ApiController]
    public class ProfessionalController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ProfessionalViewModel>> CreateProfessional([FromBody] CreateProfessionalDTO data)
        {
            var command = new CreateEntityCommand<Professional, CreateProfessionalDTO, ProfessionalViewModel>(data);
            var professional = await _mediator.Send(command);
            return Created("api/professional", professional);
        }

        [HttpGet("all")]
        public async Task<ActionResult<ProfessionalViewModel>> GetAllProfessionals()
        {
            var query = new GetAllEntitiesQuery<ProfessionalViewModel>();
            var professionals = await _mediator.Send(query);
            return Ok(professionals);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProfessionalViewModel>> GetProfessionalById(Guid id)
        {
            var query = new GetEntityByIdQuery<ProfessionalViewModel>(id);
            var professional = await _mediator.Send(query);
            return Ok(professional);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProfessionalViewModel>> UpdateProfessional(Guid id, UpdateProfessionalDTO data)
        {
            var command = new UpdateEntityCommand<Professional, UpdateProfessionalDTO, ProfessionalViewModel>(id, data);
            var professional = await _mediator.Send(command);
            return Ok(professional);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProfessionalViewModel>> DeleteProfessional(Guid id)
        {
            var command = new DeleteEntityCommand<Professional>(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
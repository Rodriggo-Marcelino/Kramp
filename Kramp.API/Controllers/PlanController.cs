using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanController(IMediator _mediator, PlanRepository _repository, IMapper _mapper) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<ActionResult<PlanInfoViewModel>> Create(CreatePlanCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<PlanInfoViewModel>>> GetAllPlans()
    {
        var plans = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<PlanInfoViewModel>>(plans));
    }

    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<PlanInfoViewModel>> GetPlanById(Guid Id)
    {
        Plan? plan = await _repository.GetByIdAsync(Id);

        if (plan == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PlanInfoViewModel>(plan));
    }

    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult<PlanInfoViewModel>> Update(Guid Id, UpdatePlanCommand command)
    {
        command.Id = Id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("Delete/{Id:guid}")]
    public async Task<ActionResult> DeleteById(Guid Id)
    {
        //TODO: Retirar o método de delete do controller (má prática)
        await _repository.DeleteByIdAsync(Id, new CancellationToken());
        return NoContent();
    }
}
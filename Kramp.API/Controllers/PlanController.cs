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

    // TODO: Implementar os métodos abaixo
    [HttpPost("{planId:guid}/Workouts")]
    public async Task<IActionResult> AddWorkoutToPlan(Guid planId /*, AddWorkoutToPlanCommand command*/)
    {
        //command.PlanId = planId;
        // Lógica para adicionar o Workout ao Plan
        return Ok();
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<PlanInfoViewModel>>> GetAllPlans()
    {
        var plans = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<PlanInfoViewModel>>(plans));
    }

    // TODO: Implementar os métodos abaixo
    [HttpGet("All")]
    public async Task<ActionResult<List<PlanInfoViewModel>>> GetAllPlans(int pageNumber = 1, int pageSize = 10)
    {
        // Lógica para buscar os planos com paginação
        return Ok();
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

    // TODO: Implementar os métodos abaixo
    [HttpDelete("{planId:guid}/Workouts/{workoutId:guid}")]
    public async Task<IActionResult> RemoveWorkoutFromPlan(Guid planId, Guid workoutId)
    {
        // Lógica para remover o Workout do Plan
        return NoContent();
    }
}
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
    #region POST

    [HttpPost("Create/Simple")]
    public async Task<ActionResult<SimplePlanViewModel>> CreateSimple(CreateSimplePlanCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpPost("Create/Complete")]
    public async Task<ActionResult<SimplePlanViewModel>> CreateComplete(CreateCompletePlanCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpPost("{planId:guid}/Workouts")]
    public async Task<IActionResult> AddWorkoutToPlan(Guid planId, AddWorkoutToPlanCommand command)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{planId:guid}/Workouts/List")]
    public async Task<IActionResult> AddListWorkoutToPlan(Guid planId, List<AddWorkoutToPlanCommand> command)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region GET

    [HttpGet("All/Simple")]
    public async Task<ActionResult<IEnumerable<SimplePlanViewModel>>> GetAllPlans()
    {
        var plans = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<SimplePlanViewModel>>(plans));
    }

    [HttpGet("All/Details")]
    public async Task<ActionResult<IEnumerable<CompletePlanViewModel>>> GetAllPlansDetail()
    {
        var plans = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CompletePlanViewModel>>(plans));
    }

    [HttpGet("{Id:guid}/Simple")]
    public async Task<ActionResult<SimplePlanViewModel>> GetPlanById(Guid Id)
    {
        Plan? plan = await _repository.GetByIdAsync(Id);

        if (plan == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SimplePlanViewModel>(plan));
    }

    [HttpGet("{Id:guid}/Details")]
    public async Task<ActionResult<CompletePlanViewModel>> GetPlanDetailById(Guid Id)
    {
        Plan? plan = await _repository.GetByIdAsync(Id);

        if (plan == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CompletePlanViewModel>(plan));
    }

    [HttpGet("All/Simple/Page")]
    public async Task<ActionResult<List<SimplePlanViewModel>>> GetAllPlans([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    [HttpGet("All/Details/Page")]
    public async Task<ActionResult<List<SimplePlanViewModel>>> GetAllPlansDetail([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{planId:guid}/Workouts")]
    public async Task<ActionResult<List<PlanWorkoutViewModel>>> GetPlanWorkoutsById(Guid planId)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region PUT

    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult<SimplePlanViewModel>> Update(Guid Id, UpdateSimplePlanCommand command)
    {
        command.Id = Id;
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{planId:guid}/Workouts")]
    public async Task<IActionResult> UpdateWorkouts(Guid planId, UpdateWorkoutsInPlanCommand command)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region DELETE

    [HttpDelete("Delete/{Id:guid}")]
    public async Task<ActionResult> DeleteById(Guid Id)
    {
        //TODO: Retirar o método de delete do controller (má prática)
        await _repository.DeleteByIdAsync(Id);
        return NoContent();
    }

    [HttpDelete("{planId:guid}/Workouts/{workoutId:guid}")]
    public async Task<IActionResult> RemoveWorkoutFromPlan(Guid planId, Guid workoutId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{planId:guid}/Workouts")]
    public async Task<IActionResult> RemoveAllWorkoutsFromPlan(Guid planId)
    {
        throw new NotImplementedException();
    }

    #endregion
}
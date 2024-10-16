using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.DTOs.Update;
using Application.CQRS.ViewModels;
using Domain.Entity.Training;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers.Training;

[Route("api/plans")]
[ApiController]
public class PlanController(IMediator _mediator) : ControllerBase
{
    #region POST

    [HttpPost("simple")]
    public async Task<ActionResult<SimplePlanViewModel>> CreateSimple(CreateSimplePlanDTO data)
    {
        var command = new CreateEntityCommand<Plan, CreateSimplePlanDTO, SimplePlanViewModel>(data);
        var result = await _mediator.Send(command);
        return Created("", result);
    }

    [HttpPost("details")]
    public async Task<ActionResult<CompletePlanViewModel>> CreateComplete(CreateCompletePlanDTO data)
    {
        var command = new CreateEntityCommand<Plan, CreateCompletePlanDTO, CompletePlanViewModel>(data);
        var result = await _mediator.Send(command);
        return Created("", result);
    }

    [HttpPost("{id:guid}/workouts")]
    public async Task<IActionResult> AddWorkoutToPlan(Guid id, AddWorkoutToPlanDTO data)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{id:guid}/workouts/list")]
    public async Task<IActionResult> AddListWorkoutToPlan(Guid id, List<AddWorkoutToPlanDTO> data)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region GET

    [HttpGet("simple/all")]
    public async Task<ActionResult<IEnumerable<SimplePlanViewModel>>> GetAllPlans()
    {
        throw new NotImplementedException();
    }

    [HttpGet("details/all")]
    public async Task<ActionResult<IEnumerable<CompletePlanViewModel>>> GetAllPlansDetail()
    {
        throw new NotImplementedException();
    }

    [HttpGet("simple/all/page")]
    public async Task<ActionResult<List<SimplePlanViewModel>>> GetAllPlans([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    [HttpGet("details/all/page")]
    public async Task<ActionResult<List<SimplePlanViewModel>>> GetAllPlansDetail([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}/simple")]
    public async Task<ActionResult<SimplePlanViewModel>> GetPlanById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}/details")]
    public async Task<ActionResult<CompletePlanViewModel>> GetPlanDetailById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}/plans")]
    public async Task<ActionResult<List<PlanWorkoutViewModel>>> GetPlanWorkoutsById(Guid id)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region PUT

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<SimplePlanViewModel>> Update(Guid Id, UpdateSimplePlanDTO data)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}/workouts")]
    public async Task<IActionResult> UpdateWorkouts(Guid planId, UpdateWorkoutInPlanDTO data)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region DELETE

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteById(Guid id)
    {
        var command = new DeleteEntityCommand<Plan>(id);
        await _mediator.Send(command);
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
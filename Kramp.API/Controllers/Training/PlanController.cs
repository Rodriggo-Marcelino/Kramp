using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.DTOs.Create.Training;
using Application.CQRS.DTOs.Update.Training;
using Application.CQRS.Queries;
using Application.CQRS.ViewModels.Training;
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
        data.WorkoutId = id;
        var command = new CreateEntityCommand<PlanWorkout, AddWorkoutToPlanDTO, PlanWorkoutViewModel>(data);
        var result = await _mediator.Send(command);
        return Created("api/plans/{id}/workouts", result);
    }

    [HttpPost("{id:guid}/workouts/list")]
    public async Task<IActionResult> AddListWorkoutToPlan(Guid id, List<AddWorkoutToPlanDTO> data)
    {
        data.ForEach(x => x.PlanId = id);
        var command = new CreateEntityCommand<PlanWorkout, AddWorkoutToPlanDTO, PlanWorkoutViewModel>(data);
        var result = await _mediator.Send(command);
        return Created("api/plans/{id}/workouts/list", result);
    }

    #endregion

    #region GET

    [HttpGet("simple/all")]
    public async Task<ActionResult<IEnumerable<SimplePlanViewModel>>> GetAllPlans()
    {
        var query = new GetAllEntitiesQuery<SimplePlanViewModel>();
        var plans = await _mediator.Send(query);
        return Ok(plans);
    }

    [HttpGet("details/all")]
    public async Task<ActionResult<IEnumerable<CompletePlanViewModel>>> GetAllPlansDetail()
    {
        var query = new GetAllEntitiesQuery<CompletePlanViewModel>();
        var plans = await _mediator.Send(query);
        return Ok(plans);
    }

    [HttpGet("simple/all/page")]
    public async Task<ActionResult<List<SimplePlanViewModel>>> GetAllPlans([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetAllEntitiesQuery<SimplePlanViewModel>(pageNumber, pageSize);
        var plans = await _mediator.Send(query);
        return Ok(plans);
    }

    [HttpGet("details/all/page")]
    public async Task<ActionResult<List<CompletePlanViewModel>>> GetAllPlansDetail([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetAllEntitiesQuery<CompletePlanViewModel>(pageNumber, pageSize);
        var plans = await _mediator.Send(query);
        return Ok(plans);
    }

    [HttpGet("{id:guid}/simple")]
    public async Task<ActionResult<SimplePlanViewModel>> GetPlanById(Guid id)
    {
        var query = new GetEntityByIdQuery<SimplePlanViewModel>(id);
        var plan = await _mediator.Send(query);
        return Ok(plan);
    }

    [HttpGet("{id:guid}/details")]
    public async Task<ActionResult<CompletePlanViewModel>> GetPlanDetailById(Guid id)
    {
        var query = new GetEntityByIdQuery<CompletePlanViewModel>(id);
        var plan = await _mediator.Send(query);
        return Ok(plan);
    }

    //Para Jorge: Não funciona
    [HttpGet("{id:guid}/workouts")]
    public async Task<ActionResult<List<PlanWorkoutViewModel>>> GetPlanWorkoutsById(Guid id)
    {
        var query = new GetEntityByIdQuery<PlanWorkoutViewModel>(id);
        var planWorkout = await _mediator.Send(query);
        return Ok(planWorkout);
    }

    #endregion

    #region PUT

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<SimplePlanViewModel>> Update(Guid id, UpdateSimplePlanDTO data)
    {
        data.Id = id;
        var command = new UpdateEntityCommand<Plan, UpdateSimplePlanDTO, SimplePlanViewModel>(data);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    //Para Jorge: Não funciona
    [HttpPut("{id:guid}/workouts")]
    public async Task<IActionResult> UpdateWorkouts(Guid id, UpdateWorkoutInPlanDTO data)
    {
        data.Id = id;
        var command = new UpdateEntityCommand<PlanWorkout, UpdateWorkoutInPlanDTO, PlanWorkoutViewModel>(data);
        var result = await _mediator.Send(command);
        return Ok(result);
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

    //Para Jorge: Não funciona
    [HttpDelete("{id:guid}/Workouts/{planWorkoutId:guid}")]
    public async Task<IActionResult> RemoveWorkoutFromPlan(Guid id, Guid planWorkoutId)
    {
        var command = new DeleteEntityCommand<WorkoutExercise>(planWorkoutId);
        await _mediator.Send(command);
        return NoContent();
    }

    #endregion
}
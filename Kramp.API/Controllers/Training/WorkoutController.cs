using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Domain.Entity.Training;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers.Training;

[Route("api/workouts")]
[ApiController]
public class WorkoutController(IMediator _mediator) : ControllerBase
{
    #region POST

    [HttpPost("simple")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> CreateSimpleWorkout(CreateSimpleWorkoutDTO data)
    {
        var command = new CreateEntityCommand<Workout, CreateSimpleWorkoutDTO, SimpleWorkoutViewModel>(data);
        var result = await _mediator.Send(command);
        return Created("api/workouts/simple", result);
    }

    [HttpPost("details")]
    public async Task<ActionResult<CompleteWorkoutViewModel>> CreateCompleteWorkout(CreateCompleteWorkoutDTO data)
    {
        var command = new CreateEntityCommand<Workout, CreateCompleteWorkoutDTO, CompleteWorkoutViewModel>(data);
        var result = await _mediator.Send(command);
        return Created("api/workouts/details", result);
    }

    [HttpPost("{workoutId:guid}/exercises")]
    public async Task<IActionResult> AddExerciseToWorkout(Guid workoutId, AddExerciseToWorkoutDTO data)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{workoutId:guid}/exercises/list")]
    public async Task<IActionResult> AddListOfExercisesToWorkout(Guid workoutId, List<AddExerciseToWorkoutDTO> data)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region GET

    [HttpGet("simple/all")]
    public async Task<ActionResult<IEnumerable<SimpleWorkoutViewModel>>> GetAllSimpleWorkouts()
    {
        var query = new GetAllEntitiesQuery<SimpleWorkoutViewModel>();
        var workouts = await _mediator.Send(query);
        return Ok(workouts);
    }

    [HttpGet("details/all")]
    public async Task<ActionResult<IEnumerable<CompleteWorkoutViewModel>>> GetAllCompleteWorkouts()
    {
        var query = new GetAllEntitiesQuery<CompleteWorkoutViewModel>();
        var workouts = await _mediator.Send(query);
        return Ok(workouts);
    }

    [HttpGet("simple/all/page")]
    public async Task<ActionResult<IEnumerable<SimpleWorkoutViewModel>>> GetAllSimpleWorkoutsPageable(
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllEntitiesQuery<SimpleWorkoutViewModel>(pageNumber, pageSize);
        var workouts = await _mediator.Send(query);
        return Ok(workouts);
    }

    [HttpGet("details/all/page")]
    public async Task<ActionResult<IEnumerable<SimpleWorkoutViewModel>>> GetAllCompleteWorkoutsPageable(
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllEntitiesQuery<CompleteWorkoutViewModel>(pageNumber, pageSize);
        var workouts = await _mediator.Send(query);
        return Ok(workouts);
    }

    [HttpGet("{id:guid}/simple")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> GetSimpleWorkoutById(Guid id)
    {
        var query = new GetEntityByIdQuery<SimpleWorkoutViewModel>(id);
        var workout = await _mediator.Send(query);
        return Ok(workout);
    }

    [HttpGet("{id:guid}/details")]
    public async Task<ActionResult<CompleteWorkoutViewModel>> GetCompleteWorkoutById(Guid id)
    {
        var query = new GetEntityByIdQuery<CompleteWorkoutViewModel>(id);
        var workout = await _mediator.Send(query);
        return Ok(workout);
    }

    [HttpGet("{id:guid}/exercises")]
    public async Task<ActionResult<WorkoutExerciseViewModel>> GetWorkoutExercisesById(Guid id)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region PUT

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> UpdateWorkout(Guid id, UpdateSimpleWorkoutDTO data)
    {
        var command = new UpdateEntityCommand<Workout, UpdateSimpleWorkoutDTO, SimpleWorkoutViewModel>(id, data);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}/exercises")]
    public async Task<IActionResult> UpdateWorkoutExercise(Guid id, UpdateExerciseInWorkoutDTO data)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region DELETE

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteWorkout(Guid id)
    {
        var command = new DeleteEntityCommand<Workout>(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}/exercises/{exerciseId:guid}")]
    public async Task<IActionResult> RemoveExerciseFromWorkout(Guid id, Guid exerciseId)
    {
        throw new NotImplementedException();
    }

    #endregion
}
using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutController(IMediator _mediator, WorkoutRepository _repository, IMapper _mapper) : ControllerBase
{
    #region POST

    [HttpPost("Create/Simple")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> CreateSimple(CreateSimpleWorkoutCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpPost("Create/Details")]
    public async Task<ActionResult<CompleteWorkoutViewModel>> CreateComplete(CreateCompleteWorkoutCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpPost("{workoutId:guid}/Exercises")]
    public async Task<IActionResult> AddExerciseToWorkout(Guid workoutId, AddExerciseToWorkoutCommand command)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{workoutId:guid}/Exercises/List")]
    public async Task<IActionResult> AddListExerciseToWorkout(Guid workoutId, List<AddExerciseToWorkoutCommand> command)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region GET

    [HttpGet("All/Simple")]
    public async Task<ActionResult<IEnumerable<SimpleWorkoutViewModel>>> GetAllSimpleWorkouts()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<SimpleWorkoutViewModel>>(workouts));
    }

    [HttpGet("All/Details")]
    public async Task<ActionResult<IEnumerable<CompleteWorkoutViewModel>>> GetAllCompleteWorkouts()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CompleteWorkoutViewModel>>(workouts));
    }

    [HttpGet("All/Simple/Page")]
    public async Task<ActionResult<List<SimpleWorkoutViewModel>>> GetAllSimpleWorkoutsPageable(
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    [HttpGet("All/Details/Page")]
    public async Task<ActionResult<List<SimpleWorkoutViewModel>>> GetAllCompleteWorkoutsPageable(
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{Id:guid}/Simple")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> GetSimpleWorkoutById(Guid Id)
    {
        Workout? workout = await _repository.GetByIdAsync(Id);

        if (workout == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SimpleWorkoutViewModel>(workout));
    }

    [HttpGet("{Id:guid}/Details")]
    public async Task<ActionResult<CompleteWorkoutViewModel>> GetCompleteWorkoutById(Guid Id)
    {
        Workout? workout = await _repository.GetByIdAsync(Id);

        if (workout == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CompleteWorkoutViewModel>(workout));
    }

    [HttpGet("{Id:guid}/Exercises")]
    public async Task<ActionResult<WorkoutExerciseViewModel>> GetWorkoutExercisesById(Guid Id)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region PUT

    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> Update(Guid Id, UpdateSimpleWorkoutCommand command)
    {
        command.Id = Id;
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{workoutId:guid}/Exercises")]
    public async Task<IActionResult> UpdateWorkoutExercise(Guid workoutId, UpdateWorkoutExerciseCommand command)
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

    [HttpDelete("{workoutId:guid}/Exercises/{exerciseId:guid}")]
    public async Task<IActionResult> RemoveExerciseFromWorkout(Guid workoutId, Guid exerciseId)
    {
        throw new NotImplementedException();
    }

    #endregion
}
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
    [HttpPost("Create")]
    public async Task<ActionResult<WorkoutInfoViewModel>> Create(CreateWorkoutCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpGet("All")]
    public async Task<ActionResult<IEnumerable<WorkoutInfoViewModel>>> GetAllWorkouts()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<WorkoutInfoViewModel>>(workouts));
    }

    // TODO: Implementar os métodos abaixo
    [HttpGet("All")]
    public async Task<ActionResult<List<WorkoutInfoViewModel>>> GetAllWorkouts(int pageNumber = 1, int pageSize = 10)
    {
        //var workouts = await _repository.GetAllAsync(pageNumber, pageSize);
        //var mappedWorkouts = _mapper.Map<List<WorkoutInfoViewModel>>(workouts);
        //var pagedWorkouts = new PagedList<WorkoutInfoViewModel>(mappedWorkouts, workouts.TotalCount, workouts.CurrentPage, workouts.PageSize);

        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<WorkoutInfoViewModel>> GetWorkoutById(Guid Id)
    {
        Workout? workout = await _repository.GetByIdAsync(Id);

        if (workout == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<WorkoutInfoViewModel>(workout));
    }

    // TODO: Implementar os métodos abaixo
    [HttpGet("{Id:guid}/Exercises")]
    public async Task<ActionResult<WorkoutInfoViewModel>> GetWorkoutExercisesById(Guid Id)
    {
        throw new NotImplementedException();
    }

    // TODO: Implementar os métodos abaixo
    [HttpPost("{workoutId:guid}/Exercises")]
    public async Task<IActionResult> AddExerciseToWorkout(Guid workoutId /*, AddExerciseToWorkoutCommand command*/)
    {
        //command.WorkoutId = workoutId;
        // Lógica para adicionar o exercício ao Workout
        return Ok();
    }

    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult<WorkoutInfoViewModel>> Update(Guid Id, UpdateWorkoutCommand command)
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
    [HttpDelete("{workoutId:guid}/Exercises/{exerciseId:guid}")]
    public async Task<IActionResult> RemoveExerciseFromWorkout(Guid workoutId, Guid exerciseId)
    {
        // Lógica para remover o exercício do Workout
        return NoContent();
    }

    // TODO: Endpoint de Workout+Exercises (GET)
}
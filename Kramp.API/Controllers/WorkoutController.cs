using Application.WorkoutCQ.Commands;
using Application.WorkoutCQ.ViewModels;
using AutoMapper;
using Domain.Entity;
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

    [HttpGet("{Id:guid}/Exercises")]
    public async Task<ActionResult<WorkoutInfoViewModel>> GetWorkoutExercisesById(Guid Id)
    {
        Workout? workout = await _repository.GetByIdAsync(Id);

        if (workout == null)
        {
            return NotFound();
        }

        var workoutViewModel = _mapper.Map<WorkoutInfoViewModel>(workout);

        return Ok(workoutViewModel.Exercises);
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
}
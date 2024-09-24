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
    /*
     * Lista de Endpoints Necessários para Workouts:
     * 
     * -- Criar Treino (Workouts) --
     * POST /api/workouts (Cria um novo treino com informações básicas)
     * POST /api/workouts/complete (Cria um novo treino com detalhes completos, incluindo exercícios)
     * 
     * -- Ler Treinos (Workouts) --
     * GET /api/workouts (Retorna todos os treinos com informações básicas)
     * GET /api/workouts/details (Retorna todos os treinos com detalhes completos, incluindo exercícios)
     * GET /api/workouts/{id} (Retorna um treino específico pelo ID com informações básicas)
     * GET /api/workouts/{id}/details (Retorna um treino específico com detalhes completos)
     * GET /api/workouts/{id}/exercises (Retorna todos os exercícios de um treino específico)
     * 
     * -- Buscar Exercícios (Exercises) --
     * GET /api/exercises (Retorna todos os exercícios disponíveis no sistema)
     * GET /api/exercises/{exerciseId} (Retorna detalhes de um exercício específico)
     * 
     * -- Atualizar Treino (Workouts) --
     * PUT /api/workouts/{id} (Atualiza as informações de um treino específico)
     * PUT /api/workouts/{id}/exercises (Atualiza um ou mais exercícios de um treino específico)
     * 
     * -- Deletar Treino (Workouts) --
     * DELETE /api/workouts/{id} (Exclui um treino específico)
     * DELETE /api/workouts/{id}/exercises/{exerciseId} (Remove um exercício específico de um treino)
     */

    [HttpPost("Create/Simple")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> CreateSimple(CreateSimpleWorkoutCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    [HttpPost("Create/Complete")]
    public async Task<ActionResult<CompleteWorkoutViewModel>> CreateComplete(CreateCompleteWorkoutCommand command)
    {
        return Created("", await _mediator.Send(command));
    }

    // TODO: Implementar os métodos abaixo
    [HttpPost("{workoutId:guid}/Exercises")]
    public async Task<IActionResult> AddExerciseToWorkout(Guid workoutId /*, AddExerciseToWorkoutCommand command*/)
    {
        //command.WorkoutId = workoutId;
        // Lógica para adicionar o exercício ao Workout
        return Ok();
    }

    [HttpGet("All/Simple")]
    public async Task<ActionResult<IEnumerable<SimpleWorkoutViewModel>>> GetAllSimpleWorkouts()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<SimpleWorkoutViewModel>>(workouts));
    }

    [HttpGet("All/Complete")]
    public async Task<ActionResult<IEnumerable<CompleteWorkoutViewModel>>> GetAllCompleteWorkouts()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<SimpleWorkoutViewModel>>(workouts));
    }

    /*
    // TODO: Implementar os métodos abaixo
    [HttpGet("All")]
    public async Task<ActionResult<List<WorkoutInfoViewModel>>> GetAllWorkouts(int pageNumber = 1, int pageSize = 10)
    {
        //var workouts = await _repository.GetAllAsync(pageNumber, pageSize);
        //var mappedWorkouts = _mapper.Map<List<WorkoutInfoViewModel>>(workouts);
        //var pagedWorkouts = new PagedList<WorkoutInfoViewModel>(mappedWorkouts, workouts.TotalCount, workouts.CurrentPage, workouts.PageSize);

        return Ok();
    }
    */

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

    [HttpGet("{Id:guid}/Complete")]
    public async Task<ActionResult<CompleteWorkoutViewModel>> GetCompleteWorkoutById(Guid Id)
    {
        Workout? workout = await _repository.GetByIdAsync(Id);

        if (workout == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SimpleWorkoutViewModel>(workout));
    }

    // TODO: Implementar os métodos abaixo
    [HttpGet("{Id:guid}/Exercises")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> GetWorkoutExercisesById(Guid Id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult<SimpleWorkoutViewModel>> Update(Guid Id, UpdateSimpleWorkoutCommand command)
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
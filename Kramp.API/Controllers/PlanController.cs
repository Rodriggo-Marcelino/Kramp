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
    /*
     * Lista de Endpoints Necessários para Plans:
     * 
     * -- Criar Plano --
     * POST /api/plans (Cria um novo plano com informações básicas)
     * POST /api/plans/complete (Cria um novo plano com detalhes completos, incluindo treinos)
     * 
     * -- Adicionar Treinos ao Plano --
     * POST /api/plans/{planId}/workouts (Adiciona um treino a um plano existente)
     * POST /api/plans/{planId}/workouts/list (Adiciona uma lista de treino a um plano especifico)
     * 
     * -- Ler Planos (Plans) --
     * GET /api/plans (Retorna todos os planos cadastrados)
     * GET /api/plans/{id} (Retorna um plano específico pelo ID)
     * GET /api/plans/details (Retorna todos os planos com detalhes completos, incluindo treinos)
     * GET /api/plans/{pageNumber}/{pageSize} (Retorna todos os planos cadastrados com paginação)
     * GET /api/plans/details/{pageNumber}/{pageSize} (Retorna todos os planos cadastrados com paginação)
     * GET /api/plans/{planId}/workouts (Retorna todos os treinos associados a um plano específico)
     * 
     * -- Atualizar Plano (Plans) --
     * PUT /api/plans/{id} (Atualiza as informações de um plano específico)
     * PUT /api/plans/{id}/workouts (Atualiza os workouts de um plano específico)
     * 
     * -- Remover Plano ou Treinos do Plano --
     * DELETE /api/plans/{id} (Remove um plano específico do sistema)
     * DELETE /api/plans/{planId}/workouts/{workoutId} (Remove um treino específico de um plano)
     * DELETE /api/plans/{planId}/workouts (Remove todos os treinos de um plano específico)
     */

    [HttpPost("Create")]
    public async Task<ActionResult<SimplePlanViewModel>> Create(CreatePlanCommand command)
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
    public async Task<ActionResult<IEnumerable<SimplePlanViewModel>>> GetAllPlans()
    {
        var plans = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<SimplePlanViewModel>>(plans));
    }

    /*
    // TODO: Implementar os métodos abaixo
    [HttpGet("All")]
    public async Task<ActionResult<List<PlanInfoViewModel>>> GetAllPlans(int pageNumber = 1, int pageSize = 10)
    {
        // Lógica para buscar os planos com paginação
        return Ok();
    }
    */

    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<SimplePlanViewModel>> GetPlanById(Guid Id)
    {
        Plan? plan = await _repository.GetByIdAsync(Id);

        if (plan == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SimplePlanViewModel>(plan));
    }

    [HttpPut("Update/{Id:guid}")]
    public async Task<ActionResult<SimplePlanViewModel>> Update(Guid Id, UpdatePlanCommand command)
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
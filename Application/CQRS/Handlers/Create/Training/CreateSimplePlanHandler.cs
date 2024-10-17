using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create.Training;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create.Training;

public class
    CreateSimplePlanHandler(PlanRepository repository, IMapper mapper) : CreateEntityTemplate<
        Plan,
        CreateEntityCommand<Plan, CreateSimplePlanDTO, SimplePlanViewModel>,
        CreateSimplePlanDTO,
        SimplePlanViewModel,
        PlanRepository>(repository, mapper)
{
}
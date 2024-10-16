using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create;

public class
    CreateSimplePlanHandler(PlanRepository repository, IMapper mapper) : CreateEntityTemplate<
        Plan,
        CreateEntityCommand<Plan, CreateSimplePlanDTO, SimplePlanViewModel>,
        CreateSimplePlanDTO,
        SimplePlanViewModel,
        PlanRepository>(repository, mapper)
{
}
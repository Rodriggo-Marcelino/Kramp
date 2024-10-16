using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update;

public class
    UpdateSimplePlanHandler(PlanRepository repository, IMapper mapper) : UpdateEntityTemplate<
    Plan,
    UpdateEntityCommand<Plan, UpdateSimplePlanDTO, SimplePlanViewModel>,
    UpdateSimplePlanDTO,
    SimplePlanViewModel,
    PlanRepository>(repository, mapper)
{

}
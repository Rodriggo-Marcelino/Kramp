using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create.Training
{
    public class AddWorkoutInPlanHandler(PlanWorkoutRepository repository, IMapper mapper)
        : CreateEntityTemplate<
            PlanWorkout,
            CreateEntityCommand<PlanWorkout, AddWorkoutToPlanDTO, PlanWorkoutViewModel>,
            AddWorkoutToPlanDTO,
            PlanWorkoutViewModel,
            PlanWorkoutRepository>(repository, mapper)
    {
    }
}

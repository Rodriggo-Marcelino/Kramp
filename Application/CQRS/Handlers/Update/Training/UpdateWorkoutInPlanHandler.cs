using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.Training;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.Training
{
    public class UpdateWorkoutInPlanHandler(PlanWorkoutRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
            PlanWorkout,
            UpdateEntityCommand<PlanWorkout, UpdateWorkoutInPlanDTO, PlanWorkoutViewModel>,
            UpdateWorkoutInPlanDTO,
            PlanWorkoutViewModel,
            PlanWorkoutRepository>(repository, mapper)
    {
    }
}

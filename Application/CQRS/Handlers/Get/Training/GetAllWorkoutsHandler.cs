using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get.Training;

public class GetAllWorkoutsHandler<TViewModel>
    (WorkoutRepository repository, IMapper mapper)
    : GetAllEntitiesTemplate<
    Workout,
    GetAllEntitiesQuery<TViewModel>,
    TViewModel,
    WorkoutRepository>(repository, mapper)
    where TViewModel : GenericViewModel
{
}
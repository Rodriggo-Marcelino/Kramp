using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Templates.WorkoutTemplates;

public class GetAllWorkoutsTemplate<TViewModel>
    (WorkoutRepository repository, IMapper mapper)
    : GetAllEntitiesHandler<
    Workout,
    GetAllEntitiesQuery<TViewModel>,
    TViewModel,
    WorkoutRepository>(repository, mapper)
    where TViewModel : GenericViewModel
{
}
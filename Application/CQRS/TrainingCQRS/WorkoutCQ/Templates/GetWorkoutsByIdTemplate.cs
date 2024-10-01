using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Templates;

public class GetWorkoutsByIdTemplate<TViewModel>
    (WorkoutRepository repository, IMapper mapper) 
    : GetEntityByIdHandler<
    Workout,
    GetEntityByIdQuery<TViewModel>,
    TViewModel,
    WorkoutRepository>(repository, mapper) where TViewModel : GenericViewModelBase
{
    
}
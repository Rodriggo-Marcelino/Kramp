using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Templates.WorkoutTemplates;

public class UpdateSimpleWorkoutTemplate : UpdateEntityHandler<
    Workout,
    UpdateEntityCommand<Workout, UpdateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
    UpdateSimpleWorkoutDTO,
    SimpleWorkoutViewModel,
    WorkoutRepository>
{
    public UpdateSimpleWorkoutTemplate(
        WorkoutRepository repository,
        IMapper mapper
    ) : base(repository, mapper)
    {
    }
}
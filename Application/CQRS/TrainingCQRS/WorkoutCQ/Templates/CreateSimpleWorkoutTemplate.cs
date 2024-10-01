using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Templates;

public class CreateSimpleWorkoutTemplate 
        : CreateEntityHandler<
                Workout,
                CreateEntityCommand<Workout, CreateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
                CreateSimpleWorkoutDTO,
                SimpleWorkoutViewModel,
                WorkoutRepository>
{
    public CreateSimpleWorkoutTemplate(
        WorkoutRepository repository,
        IMapper mapper
    ) : base(repository, mapper)
    {
    }
}
using Application.CQRS.Commands.Create;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create;

public class CreateSimpleWorkoutHandler
        : CreateEntityTemplate<
                Workout,
                CreateEntityCommand<Workout, CreateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
                CreateSimpleWorkoutDTO,
                SimpleWorkoutViewModel,
                WorkoutRepository>
{
    public CreateSimpleWorkoutHandler(
        WorkoutRepository repository,
        IMapper mapper
    ) : base(repository, mapper)
    {
    }
}
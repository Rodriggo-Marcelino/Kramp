using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update;

public class UpdateSimpleWorkoutHandler : UpdateEntityTemplate<
    Workout,
    UpdateEntityCommand<Workout, UpdateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
    UpdateSimpleWorkoutDTO,
    SimpleWorkoutViewModel,
    WorkoutRepository>
{
    public UpdateSimpleWorkoutHandler(
        WorkoutRepository repository,
        IMapper mapper
    ) : base(repository, mapper)
    {
    }
}
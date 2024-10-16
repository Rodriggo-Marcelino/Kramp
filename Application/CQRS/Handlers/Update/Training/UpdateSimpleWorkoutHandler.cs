using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.Training;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.Training;

public class UpdateSimpleWorkoutHandler(
    WorkoutRepository repository,
    IMapper mapper) : UpdateEntityTemplate<
    Workout,
    UpdateEntityCommand<Workout, UpdateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
    UpdateSimpleWorkoutDTO,
    SimpleWorkoutViewModel,
    WorkoutRepository>(repository, mapper);
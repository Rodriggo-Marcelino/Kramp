using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create.Training;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create.Training;

public class CreateSimpleWorkoutHandler(
    WorkoutRepository repository,
    IMapper mapper)
    : CreateEntityTemplate<
    Workout,
    CreateEntityCommand<Workout, CreateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
    CreateSimpleWorkoutDTO,
    SimpleWorkoutViewModel,
    WorkoutRepository>(repository, mapper);
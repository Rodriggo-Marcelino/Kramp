using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create;

public class CreateSimpleWorkoutHandler(
    WorkoutRepository repository,
    IMapper mapper)
    : CreateEntityTemplate<
    Workout,
    CreateEntityCommand<Workout, CreateSimpleWorkoutDTO, SimpleWorkoutViewModel>,
    CreateSimpleWorkoutDTO,
    SimpleWorkoutViewModel,
    WorkoutRepository>(repository, mapper);
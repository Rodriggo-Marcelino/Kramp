using Application.CQRS.Commands;
using Application.CQRS.Templates;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Delete.Training;

public class DeleteWorkoutHandler(WorkoutRepository repository) : DeleteEntityTemplate<Workout, DeleteEntityCommand<Workout>, WorkoutRepository>(repository)
{

}
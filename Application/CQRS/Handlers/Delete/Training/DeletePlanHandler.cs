using Application.CQRS.Commands;
using Application.CQRS.Templates;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Delete.Training
{
    public class DeletePlanHandler(PlanRepository repository) : DeleteEntityTemplate<Plan, DeleteEntityCommand<Plan>, PlanRepository>(repository)
    {
    }
}

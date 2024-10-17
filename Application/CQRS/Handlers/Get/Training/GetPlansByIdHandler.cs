using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get.Training
{
    public class GetPlansByIdHandler<TViewModel>(PlanRepository repository, IMapper mapper)
        : GetEntityByIdTemplate<Plan, GetEntityByIdQuery<TViewModel>, TViewModel, PlanRepository>(repository, mapper)
        where TViewModel : GenericViewModel
    {
    }
}

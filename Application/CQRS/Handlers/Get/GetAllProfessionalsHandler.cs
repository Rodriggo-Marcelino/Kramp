using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get
{
    public class GetAllProfessionalshandler
        (ProfessionalRepository repository, IMapper mapper)
        : GetAllEntitiesTemplate<
            Professional,
            GetAllEntitiesQuery<ProfessionalViewModel>,
            ProfessionalViewModel,
            ProfessionalRepository>(repository, mapper);
}

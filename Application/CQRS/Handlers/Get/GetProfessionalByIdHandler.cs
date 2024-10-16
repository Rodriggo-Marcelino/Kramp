using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get
{
    public class GetProfessionalByIdTemplate
        (ProfessionalRepository repository, IMapper mapper)
        : GetEntityByIdTemplate<
            Professional,
            GetEntityByIdQuery<ProfessionalViewModel>,
            ProfessionalViewModel,
            ProfessionalRepository>(repository, mapper);
}

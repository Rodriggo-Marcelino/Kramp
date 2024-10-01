using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Templates
{
    public class GetProfessionalByIdTemplate
        (ProfessionalRepository repository, IMapper mapper)
        : GetEntityByIdHandler<
            Professional,
            GetEntityByIdQuery<ProfessionalViewModel>,
            ProfessionalViewModel,
            ProfessionalRepository>(repository, mapper);
}

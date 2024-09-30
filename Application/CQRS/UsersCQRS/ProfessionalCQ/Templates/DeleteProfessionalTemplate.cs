using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Templates
{
    public class DeleteProfessionalTemplate(ProfessionalRepository repository)
        : DeleteEntityTemplate<
            Professional,
            DeleteEntityCommand<Professional>,
            ProfessionalRepository>(repository);
}

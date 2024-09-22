using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.MemberCQ.Commands;

namespace Application.CQRS.UsersCQRS.MemberCQ.Validators
{
    public class CreateMemberCommandValidator : CreateUserGenericCommandValidator<CreateMemberCommand>
    {
        //TODO: Implementar validação de usuario para criação de treino 
    }
}

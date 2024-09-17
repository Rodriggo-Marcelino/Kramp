using Application.GenericsCQRS.User.Validators;
using Application.MemberCQ.Commands;
using FluentValidation;

namespace Application.MemberCQ.Validators
{
    public class CreateMemberCommandValidator : CreateUserGenericCommandValidator<CreateMemberCommand>
    {
        //TODO: Implementar validação de usuario para criação de treino 
    }
}

using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.Generics;
using FluentValidation;

namespace Application.CQRS.GenericsCQRS.User.Validators;

public class CreateUserCommandValidator<TEntity, TCommand, TDTO, TViewModel>
    : AbstractValidator<TCommand>
    where TEntity : UserGeneric
    where TCommand : CreateEntityCommandBase<TEntity, TDTO, TViewModel>
    where TDTO : CreateUserDTO
    where TViewModel : UserViewModel
{
    private readonly ValidatorHelper _helper;

    public CreateUserCommandValidator(ValidatorHelper helper)
    {
        _helper = helper;

        RuleFor(x => x.Data.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(2).WithMessage("O nome deve ter no mínimo 2 caracteres.");

        RuleFor(x => x.Data.Surname)
            .NotEmpty().WithMessage("O sobrenome é obrigatório.")
            .MinimumLength(2).WithMessage("O sobrenome deve ter no mínimo 2 caracteres.");

        RuleFor(x => x.Data.UserBio)
            .MinimumLength(10).WithMessage("A biografia deve ter no mínimo 10 caracteres.")
            .When(x => !string.IsNullOrEmpty(x.Data.UserBio));

        RuleFor(x => x.Data.BirthDate)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
            .Must(_helper.BeAtLeast18YearsOld).WithMessage("O usuário deve ter pelo menos 18 anos.");

        RuleFor(x => x.Data.Username)
            .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

        RuleFor(x => x.Data.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

        RuleFor(x => x.Data.DocumentNumber)
            .NotEmpty().WithMessage("O número do documento é obrigatório.")
            .MinimumLength(5).WithMessage("O número do documento deve ter no mínimo 5 caracteres.");
    }
}
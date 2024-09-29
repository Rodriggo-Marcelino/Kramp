using Application.CQRS.GenericsCQRS.User.Commands;
using Domain.Entity.Generics;
using FluentValidation;

namespace Application.CQRS.GenericsCQRS.User.Validators;

public class UpdateUserCommandValidator<TEntity, TCommand, TViewModel> : AbstractValidator<TCommand>
    where TEntity : UserGeneric
    where TCommand : UpdateUserCommand<TEntity, TViewModel>
{
    private readonly ValidatorHelper _helper;

    public UpdateUserCommandValidator(ValidatorHelper helper)
    {
        _helper = helper;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(2).WithMessage("O nome deve ter no mínimo 2 caracteres.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("O sobrenome é obrigatório.")
            .MinimumLength(2).WithMessage("O sobrenome deve ter no mínimo 2 caracteres.");

        RuleFor(x => x.UserBio)
            .MinimumLength(10).WithMessage("A biografia deve ter no mínimo 10 caracteres.")
            .When(x => !string.IsNullOrEmpty(x.UserBio));

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
            .Must(_helper.BeAtLeast18YearsOld).WithMessage("O usuário deve ter pelo menos 18 anos.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty().WithMessage("O número do documento é obrigatório.")
            .MinimumLength(5).WithMessage("O número do documento deve ter no mínimo 5 caracteres.");
    }
}
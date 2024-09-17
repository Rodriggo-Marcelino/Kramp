using Application.GenericsCQRS.User.Commands;
using FluentValidation;

namespace Application.GenericsCQRS.User.Validators;

public class CreateUserGenericCommandValidator<T> : AbstractValidator<T> where T : CreateUserGenericCommand
{
    public CreateUserGenericCommandValidator()
    {
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
            .Must(BeAtLeast18YearsOld).WithMessage("O usuário deve ter pelo menos 18 anos.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty().WithMessage("O número do documento é obrigatório.")
            .MinimumLength(5).WithMessage("O número do documento deve ter no mínimo 5 caracteres.");
    }
    
    private bool BeAtLeast18YearsOld(DateTime birthDate)
    {
        var currentDate = DateTime.Today;
        var age = currentDate.Year - birthDate.Year;
        if (birthDate.Date > currentDate.AddYears(-age)) age--;
        return age >= 18;
    }
}
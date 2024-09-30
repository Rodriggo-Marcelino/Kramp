using Application.CQRS.UsersCQRS.GymCQ.Commands;
using FluentValidation;

namespace Application.CQRS.UsersCQRS.GymCQ.Validators
{
    public class CreateGymCommandValidator : AbstractValidator<CreateGymCommand>
    {
        public CreateGymCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(2).WithMessage("O nome deve ter no mínimo 2 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(244).WithMessage("Descrição deve ter no máximo 244 caracteres.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("O número do documento é obrigatório.")
                .MinimumLength(5).WithMessage("O número do documento deve ter no mínimo 5 caracteres.");
        }
    }
}
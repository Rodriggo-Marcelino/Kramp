using Application.MemberCQ.Commands;
using FluentValidation;

namespace Application.MemberCQ.Validators
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
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
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("O número do documento é obrigatório.")
                .MinimumLength(5).WithMessage("O número do documento deve ter no mínimo 5 caracteres.");
        }

        //TODO: Implementar validação de usuario para criação de treino 
    }
}

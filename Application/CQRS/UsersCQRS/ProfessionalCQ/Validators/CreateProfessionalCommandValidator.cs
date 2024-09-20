using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;
using FluentValidation;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Validators
{
    public class CreateProfessionalCommandValidator : CreateUserGenericCommandValidator<CreateProfessionalCommand>
    {
        public CreateProfessionalCommandValidator()
        {
            RuleFor(x => x.Job)
                .NotEmpty().WithMessage("Emprego é obrigatório")
                .IsInEnum().WithErrorCode("Something Went Wrong");
        }
    }
}

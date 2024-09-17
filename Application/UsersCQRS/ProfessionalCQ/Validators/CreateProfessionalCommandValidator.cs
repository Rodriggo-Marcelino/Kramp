using Application.GenericsCQRS.User.Commands;
using Application.GenericsCQRS.User.Validators;
using Application.ProfessionalCQ.Commands;
using FluentValidation;

namespace Application.ProfessionalCQ.Validators
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

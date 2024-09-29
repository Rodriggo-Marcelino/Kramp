using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Domain.Entity.User;
using FluentValidation;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Validators
{
    public class CreateProfessionalCommandValidator : CreateUserGenericCommandValidator<Professional, CreateProfessionalCommand, ProfessionalInfoViewModel>
    {
        public CreateProfessionalCommandValidator(ValidatorHelper helper) : base(helper)
        {
            RuleFor(x => x.Job)
                .NotEmpty().WithMessage("Emprego é obrigatório")
                .IsInEnum().WithErrorCode("Something Went Wrong");
        }
    }
}

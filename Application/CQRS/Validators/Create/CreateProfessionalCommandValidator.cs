using Application.CQRS.DTOs.Create;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;
using FluentValidation;

namespace Application.CQRS.Validators.Create
{
    public class CreateProfessionalCommandValidator
        : CreateUserCommandValidator<Professional, CreateProfessionalDTO>
    {
        public CreateProfessionalCommandValidator(ValidatorHelper helper) : base(helper)
        {
            RuleFor(x => x.Job)
                .NotEmpty()
                .WithMessage(helper.JOB_IS_REQUIRED_MSG)
                .IsInEnum();
        }
    }
}

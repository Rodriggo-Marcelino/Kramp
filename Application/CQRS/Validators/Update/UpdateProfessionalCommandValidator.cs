using Application.CQRS.DTOs.Update;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;
using FluentValidation;

namespace Application.CQRS.Validators.Update
{
    public class UpdateProfessionalCommandValidator
    : UpdateUserCommandValidator<Professional, UpdateProfessionalDTO>
    {
        public UpdateProfessionalCommandValidator(ValidatorHelper helper) : base(helper)
        {
            RuleFor(x => x.Job)
                .NotEmpty()
                .WithMessage(helper.JOB_IS_REQUIRED_MSG)
                .IsInEnum();
        }
    }
}

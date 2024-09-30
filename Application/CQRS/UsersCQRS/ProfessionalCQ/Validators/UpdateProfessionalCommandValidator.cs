using Application.CQRS.GenericsCQRS.Generic.Validator;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs;
using Domain.Entity.User;
using FluentValidation;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Validators
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

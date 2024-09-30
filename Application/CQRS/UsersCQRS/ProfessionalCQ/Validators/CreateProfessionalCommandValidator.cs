using Application.CQRS.GenericsCQRS.Generic.Validator;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs;
using Domain.Entity.User;
using FluentValidation;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Validators
{
    public class CreateProfessionalCommandValidator
        : CreateUserCommandValidator<Professional, CreateProfessionalDTO>
    {
        private readonly ValidatorHelper _helper;

        public CreateProfessionalCommandValidator(ValidatorHelper helper) : base(helper)
        {
            _helper = helper;

            RuleFor(x => x.Job)
                .NotEmpty()
                .WithMessage(_helper.JOB_IS_REQUIRED_MSG)
                .IsInEnum();
        }
    }
}

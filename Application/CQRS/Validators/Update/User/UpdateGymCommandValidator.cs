using Application.CQRS.DTOs.Update.User;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using FluentValidation;

namespace Application.CQRS.Validators.Update.User
{
    public class UpdateGymCommandValidator : AbstractValidator<UpdateGymDTO>
    {
        private readonly ValidatorHelper _helper;
        public UpdateGymCommandValidator(ValidatorHelper helper)
        {
            _helper = helper;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(_helper.NAME_IS_REQUIRED_MSG)

                .MinimumLength(_helper.NAME_MIN_LENGTH_VALUE)
                .WithMessage(_helper.NAME_MIN_LENGTH_MSG);

            RuleFor(x => x.Description)
                .MaximumLength(_helper.DESCRIPTION_MAX_LENGTH_VALUE)
                .WithMessage(_helper.DESCRIPTION_MAX_LENGTH_MSG);

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(_helper.USERNAME_IS_REQUIRED_MSG);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .WithMessage(_helper.DOCUMENT_NUMBER_IS_REQUIRED_MSG)

                .MinimumLength(_helper.DOCUMENT_NUMBER_MIN_LENGTH_VALUE)
                .WithMessage(_helper.DOCUMENT_NUMBER_MIN_LENGTH_MSG);
        }
    }
}
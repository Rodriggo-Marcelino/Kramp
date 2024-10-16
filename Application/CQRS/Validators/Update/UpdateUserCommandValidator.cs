using Application.CQRS.DTOs.Update;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.Generics;
using FluentValidation;

namespace Application.CQRS.Validators.Update;

public class UpdateUserCommandValidator<TEntity, TDTO>
    : AbstractValidator<TDTO>
    where TEntity : UserGeneric
    where TDTO : UpdateUserDTO
{
    private readonly ValidatorHelper _helper;

    public UpdateUserCommandValidator(ValidatorHelper helper)
    {
        _helper = helper;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(_helper.NAME_IS_REQUIRED_MSG)

            .MinimumLength(_helper.NAME_MIN_LENGTH_VALUE)
            .WithMessage(_helper.NAME_MIN_LENGTH_MSG);

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage(_helper.SURNAME_IS_REQUIRED_MSG)

            .MinimumLength(_helper.SURNAME_MIN_LENGTH_VALUE)
            .WithMessage(_helper.SURNAME_MIN_LENGTH_MSG);

        RuleFor(x => x.UserBio)
            .MinimumLength(_helper.BIO_MIN_LENGTH_VALUE)
            .WithMessage(_helper.BIO_MIN_LENGTH_MSG)
            .When(x => !string.IsNullOrEmpty(x.UserBio));

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage(_helper.BIRTHDATE_IS_REQUIRED_MSG)

            .Must(_helper.BeAtLeast18YearsOld)
            .WithMessage(_helper.BIRTHDATE_MIN_AGE_MSG);

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
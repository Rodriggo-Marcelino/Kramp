using Application.CQRS.GenericsCQRS.User.Commands;
using Domain.Entity.Generics;
using FluentValidation;

namespace Application.CQRS.GenericsCQRS.User.Validators;

public class CreateUserCommandValidator<TEntity, TDTO>
    : AbstractValidator<TDTO>
    where TEntity : UserGeneric
    where TDTO : CreateUserDTO
{
    private readonly ValidatorHelper _helper;

    public CreateUserCommandValidator(ValidatorHelper helper)
    {
        _helper = helper;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(_helper.NAME_IS_REQUIRED)
            .MinimumLength(2).WithMessage(_helper.NAME_MIN_LENGTH);

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage(_helper.SURNAME_IS_REQUIRED)
            .MinimumLength(2).WithMessage(_helper.SURNAME_MIN_LENGTH);

        RuleFor(x => x.UserBio)
            .MinimumLength(10).WithMessage(_helper.BIO_MIN_LENGTH)
            .When(x => !string.IsNullOrEmpty(x.UserBio));

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage(_helper.PASSWORD_IS_REQUIRED)
            .Must(_helper.BeAtLeast18YearsOld).WithMessage(_helper.PASSWORD_MIN_LENGTH);

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(_helper.USERNAME_IS_REQUIRED);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(_helper.PASSWORD_IS_REQUIRED)
            .MinimumLength(6).WithMessage(_helper.PASSWORD_MIN_LENGTH);

        RuleFor(x => x.DocumentNumber)
            .NotEmpty().WithMessage(_helper.DOCUMENT_NUMBER_IS_REQUIRED)
            .MinimumLength(5).WithMessage(_helper.DOCUMENT_NUMBER_MIN_LENGTH);
    }
}
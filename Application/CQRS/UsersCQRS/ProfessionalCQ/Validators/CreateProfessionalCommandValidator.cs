using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTO;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Domain.Entity.User;
using FluentValidation;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Validators
{
    public class CreateProfessionalCommandValidator :
        CreateUserCommandValidator<
            Professional,
            CreateEntityCommandBase<Professional, CreateProfessionalDTO, ProfessionalInfoViewModel>,
            CreateProfessionalDTO,
            ProfessionalInfoViewModel>
    {
        public CreateProfessionalCommandValidator(ValidatorHelper helper) : base(helper)
        {
            RuleFor(x => x.Data.Job)
                .NotEmpty().WithMessage("Emprego é obrigatório")
                .IsInEnum().WithErrorCode("Something Went Wrong");
        }
    }
}

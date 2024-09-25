using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using FluentValidation;

namespace Application.CQRS.GenericsCQRS.Generic.Validators
{
    public class CreateEntityCommandValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : CreateEntityCommand<GenericViewModel>
    {
        public CreateEntityCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(2).WithMessage("O nome deve ter no mínimo 2 caracteres.");
        }
    }
}

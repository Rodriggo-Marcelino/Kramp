using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using Domain.Entity.Generics;
using FluentValidation;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public class CreateEntityCommandHandler<TEntity, TCommand, TViewModel, TRepository, TValidator> : IRequestHandler<TCommand, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TCommand : IRequest<ResponseBase<TViewModel>>
        where TViewModel : GenericViewModel
        where TRepository : GenericRepository<TEntity>
        where TValidator : AbstractValidator<TCommand>
    {
        private readonly CreateEntityTemplate<TEntity, TCommand, TViewModel, TRepository, TValidator> _template;

        public CreateEntityCommandHandler(CreateEntityTemplate<TEntity, TCommand, TViewModel, TRepository, TValidator> template)
        {
            _template = template;
        }

        public async Task<ResponseBase<TViewModel>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await _template.ExecuteAsync(request);
        }
    }
}

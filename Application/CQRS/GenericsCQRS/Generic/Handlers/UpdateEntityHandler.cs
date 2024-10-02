using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public abstract class UpdateEntityHandler<TEntity, TCommand, TDTO, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TCommand, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TCommand : UpdateEntityCommand<TEntity, TDTO, TViewModel>
        where TViewModel : GenericViewModelBase
        where TRepository : GenericRepository<TEntity>
        where TDTO : class
    {
        public virtual async Task<ResponseBase<TViewModel>> Handle(TCommand request,
            CancellationToken cancellationToken)
        {
            return await this.ExecuteAsync(request);
        }

        public async Task<ResponseBase<TViewModel>> ExecuteAsync(TCommand request)
        {
            TEntity? entity = await GetEntityAsync(request.Id);

            if (entity == null) throw new Exception("Entity not found.");

            TEntity updatedEntity = MapCommandToEntity(request.Data, entity);

            ManipulateEntityBeforeUpdate(updatedEntity);

            await UpdateEntityAsync(updatedEntity);

            ManipulateEntityAfterUpdate(updatedEntity);

            return CreateResponse(updatedEntity);
        }

        protected virtual async Task<TEntity?> GetEntityAsync(Guid id) => await repository.GetByIdAsync(id);

        protected virtual TEntity MapCommandToEntity(TDTO data, TEntity entity) => mapper.Map(data, entity);

        protected virtual void ManipulateEntityBeforeUpdate(TEntity entity)
        {
        }

        protected virtual async Task UpdateEntityAsync(TEntity entity) => await repository.UpdateAsync(entity);

        protected virtual void ManipulateEntityAfterUpdate(TEntity entity)
        {
        }

        protected virtual ResponseBase<TViewModel> CreateResponse(TEntity entity)
        {
            var viewModel = mapper.Map<TViewModel>(entity);
            return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
        }
    }
}
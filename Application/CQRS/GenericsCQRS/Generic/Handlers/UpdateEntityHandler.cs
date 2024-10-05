using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public abstract class UpdateEntityHandler<TEntity, TCommand, TDTO, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TCommand, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TCommand : UpdateEntityCommand<TEntity, TDTO, TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : IRepository<TEntity>
        where TDTO : class
    {
        private readonly TRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
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

            TEntity? savedUpdatedEntity = await UpdateEntityAsync(updatedEntity);

            ManipulateEntityAfterUpdate(savedUpdatedEntity);

            return CreateResponse(savedUpdatedEntity);
        }

        protected virtual async Task<TEntity?> GetEntityAsync(Guid id) => await _repository.GetByIdAsync(id);

        protected virtual TEntity MapCommandToEntity(TDTO data, TEntity entity) => _mapper.Map(data, entity);

        protected virtual void ManipulateEntityBeforeUpdate(TEntity entity)
        {
        }

        protected virtual async Task<TEntity?> UpdateEntityAsync(TEntity entity) => await _repository.UpdateAsync(entity);

        protected virtual void ManipulateEntityAfterUpdate(TEntity? entity)
        {
        }

        protected virtual ResponseBase<TViewModel> CreateResponse(TEntity? entity)
        {
            var viewModel = _mapper.Map<TViewModel>(entity);
            return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
        }
    }
}
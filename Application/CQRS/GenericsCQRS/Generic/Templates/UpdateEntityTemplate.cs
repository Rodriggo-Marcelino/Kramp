using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Templates
{
    public abstract class UpdateEntityTemplate<TEntity, TCommand, TViewModel, TRepository>
        where TEntity : EntityGeneric
        where TCommand : UpdateEntityCommand<TEntity, TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : GenericRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEntityTemplate(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<TViewModel>> ExecuteAsync(TCommand request)
        {
            ManipulateRequest(request);

            TEntity? entity = await GetEntityAsync(request.Id);

            if (entity == null)
            {
                throw new Exception("Entity not found.");
            }

            TEntity newEntity = MapCommandToEntity(request, entity);

            ManipulateEntityBeforeUpdate(entity);

            await UpdateEntityAsync(entity);

            ManipulateEntityAfterUpdate(entity);

            return CreateResponse(entity);
        }

        protected virtual void ManipulateRequest(TCommand request) { }

        protected virtual async Task<TEntity?> GetEntityAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        protected virtual TEntity MapCommandToEntity(TCommand request, TEntity entity)
        {
            return _mapper.Map(request, entity);
        }

        protected virtual void ManipulateEntityBeforeUpdate(TEntity entity) { }

        protected virtual async Task UpdateEntityAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        protected virtual void ManipulateEntityAfterUpdate(TEntity entity) { }

        protected virtual ResponseBase<TViewModel> CreateResponse(TEntity entity)
        {
            var viewModel = _mapper.Map<TViewModel>(entity);
            return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
        }
    }
}

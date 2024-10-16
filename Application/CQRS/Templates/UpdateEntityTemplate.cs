using Application.CQRS.Commands.Update;
using Application.CQRS.DTOs.Update;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.Templates
{
    public abstract class UpdateEntityTemplate<TEntity, TCommand, TDTO, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TCommand, ResponseBase<IEnumerable<TViewModel>>>
        where TEntity : EntityGeneric
        where TCommand : UpdateEntityCommand<TEntity, TDTO, TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : IRepository<TEntity>
        where TDTO : UpdateGenericDTO
    {
        private readonly TRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> Handle(TCommand request,
            CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<ResponseBase<IEnumerable<TViewModel>>> ExecuteAsync(TCommand request)
        {
            IEnumerable<TEntity> updatedEntitiesList = MapCommandToEntity(request.DataList);

            ManipulateEntityBeforeUpdate(updatedEntitiesList);

            IEnumerable<TEntity?>? savedUpdatedEntitiesList = await UpdateEntityAsync(updatedEntitiesList);

            ManipulateEntityAfterUpdate(savedUpdatedEntitiesList);

            return CreateResponse(savedUpdatedEntitiesList);
        }

        protected virtual IEnumerable<TEntity> MapCommandToEntity(IEnumerable<TDTO>? dataList)
        {
            return _mapper.Map<IEnumerable<TEntity>>(dataList);
        }

        protected virtual void ManipulateEntityBeforeUpdate(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        protected virtual async Task<IEnumerable<TEntity?>?> UpdateEntityAsync(IEnumerable<TEntity> entities)
        {
            List<TEntity> validEntities = new List<TEntity>();

            foreach (var entity in entities)
            {
                var entityFromDb = await _repository.GetByIdAsync(entity.Id);
                var updatedEntity = _mapper.Map(entity, entityFromDb);
                validEntities.Add(updatedEntity!);
            }

            if (validEntities.Count > 0)
                return await _repository.UpdateAsync(validEntities);

            return null;
        }

        protected virtual void ManipulateEntityAfterUpdate(IEnumerable<TEntity?>? entity)
        {
        }

        protected virtual ResponseBase<IEnumerable<TViewModel>> CreateResponse(IEnumerable<TEntity?>? entity)
        {
            var viewModel = _mapper.Map<IEnumerable<TViewModel>>(entity);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModel);
        }
    }
}
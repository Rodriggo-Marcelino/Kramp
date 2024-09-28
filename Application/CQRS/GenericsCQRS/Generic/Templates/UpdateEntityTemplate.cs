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
            // Fase 1: Manipular o request antes de atualizar a entidade
            ManipulateRequest(request);

            // Fase 2: Buscar a entidade no repositório
            TEntity? entity = await GetEntityAsync(request.Id);

            // Fase 3: Mapeia o comando para a entidade (pode ser personalizada)
            TEntity newEntity = MapCommandToEntity(request);

            // Fase 4: Manipular a entidade após validação, mas antes de salvar
            ManipulateEntityBeforeUpdate(entity);

            // Fase 5: Salvar a entidade no repositório
            await UpdateEntityAsync(entity);

            // Fase 6: Manipular a entidade após salvar (opcional)
            ManipulateEntityAfterUpdate(entity);

            // Fase 7: Converter a entidade para o ViewModel e retornar
            return CreateResponse(entity);
        }

        protected virtual void ManipulateRequest(TCommand request) { }

        protected virtual async Task<TEntity?> GetEntityAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        protected virtual TEntity MapCommandToEntity(TCommand request)
        {
            return _mapper.Map<TEntity>(request);
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

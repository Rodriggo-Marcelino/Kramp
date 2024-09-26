using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using FluentValidation;
using MediatR;
using Services.Repositories;

public abstract class CreateEntityTemplate<TEntity, TCommand, TViewModel, TRepository, TValidator>
    where TEntity : EntityGeneric
    where TCommand : IRequest<ResponseBase<TViewModel>>
    where TViewModel : GenericViewModel
    where TRepository : GenericRepository<TEntity>
    where TValidator : AbstractValidator<TCommand>
{
    private readonly TRepository _repository;
    private readonly IMapper _mapper;
    private readonly TValidator _validator;

    public CreateEntityTemplate(TRepository repository, IMapper mapper, TValidator validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ResponseBase<TViewModel>> ExecuteAsync(TCommand request)
    {
        // Fase 1: Manipular o request antes de criar a entidade
        ManipulateRequest(request);

        await ValidateCommandAsync(request);

        // Fase 2: Mapeia o comando para a entidade (pode ser personalizada)
        TEntity entity = MapCommandToEntity(request);

        // Fase 5: Manipular a entidade após validação, mas antes de salvar
        ManipulateEntityBeforeSave(entity);

        // Fase 6: Salvar a entidade no repositório
        await SaveEntityAsync(entity);

        // Fase 7: Manipular a entidade após salvar (opcional)
        ManipulateEntityAfterSave(entity);

        // Fase 8: Converter a entidade para o ViewModel e retornar
        return CreateResponse(entity);
    }

    // Template Methods que podem ser sobrescritos para personalizar o comportamento

    protected virtual void ManipulateRequest(TCommand request)
    {
        // Personalizar o comando antes da criação
    }

    protected virtual TEntity MapCommandToEntity(TCommand request)
    {
        // Lógica padrão de mapeamento (pode ser personalizada)
        return _mapper.Map<TEntity>(request);
    }

    protected virtual async Task ValidateCommandAsync(TCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    protected virtual void ManipulateEntityBeforeSave(TEntity entity)
    {
        // Personalizar a entidade antes de salvar (opcional)
    }

    protected virtual Task SaveEntityAsync(TEntity entity)
    {
        return _repository.AddAsync(entity);
    }

    protected virtual void ManipulateEntityAfterSave(TEntity entity)
    {
        // Personalizar a entidade após salvar (opcional)
    }

    protected virtual ResponseBase<TViewModel> CreateResponse(TEntity entity)
    {
        var viewModel = _mapper.Map<TViewModel>(entity);
        return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel, viewModel);
    }
}

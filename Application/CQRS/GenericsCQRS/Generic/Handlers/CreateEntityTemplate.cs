using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

public abstract class CreateEntityTemplate<TCommand, TEntity, TViewModel, TRepository> : IRequestHandler<TCommand, ResponseBase<TViewModel>>
    where TCommand : CreateEntityCommand<TViewModel>
    where TEntity : EntityGeneric
    where TViewModel : GenericViewModel
    where TRepository : GenericRepository<TEntity>
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;

    protected CreateEntityTemplate(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // Método template que define o fluxo genérico de criação
    public async Task<ResponseBase<TViewModel>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        // Etapas personalizáveis
        TEntity entity = CreateEntity(request);

        // Validar regras de negócio (método personalizável)
        ValidateEntity(entity);

        // Executar a lógica genérica de adição
        await _repository.AddAsync(entity);

        // Converter para o ViewModel
        var viewModel = ConvertToViewModel(entity);
        return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel, viewModel);
    }

    // Métodos que podem ser personalizados
    protected virtual TEntity CreateEntity(TCommand request)
    {
        return _mapper.Map<TEntity>(request);
    }

    protected virtual void ValidateEntity(TEntity entity)
    {
        // Validações padrão ou personalizadas por entidade
    }

    protected virtual TViewModel ConvertToViewModel(TEntity entity)
    {
        return _mapper.Map<TViewModel>(entity);
    }
}

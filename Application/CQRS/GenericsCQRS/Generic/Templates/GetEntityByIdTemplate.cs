﻿using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Templates
{
    public abstract class GetEntityByIdTemplate<TEntity, TQuery, TViewModel, TRepository>
        where TEntity : EntityGeneric
        where TQuery : IRequest<ResponseBase<TViewModel>>
        where TViewModel : GenericViewModel
        where TRepository : GenericRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        protected GetEntityByIdTemplate(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ResponseBase<TViewModel>> GetByIdAsync(Guid id)
        {
            TEntity entity = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<TViewModel>(entity);
            return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
        }
    }
}
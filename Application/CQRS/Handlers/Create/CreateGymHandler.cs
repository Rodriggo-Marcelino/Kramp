﻿using Application.CQRS.Commands.Create;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create
{
    public class CreateGymHandler(
        GymRepository repository,
        IMapper mapper,
        IAuthService authService
        ) : CreateEntityTemplate<
                Gym,
                CreateEntityCommand<Gym, CreateGymDTO, GymViewModel>,
                CreateGymDTO,
                GymViewModel,
                GymRepository>(repository, mapper)
    {
        private readonly IMapper _mapper = mapper;

        protected override void ManipulateEntityBeforeSave(IEnumerable<CreateGymDTO> request, IEnumerable<Gym> entities)
        {
            foreach (var gym in entities)
            {
                SetGymProperties(gym);
            }
        }

        protected override ResponseBase<IEnumerable<GymViewModel>> CreateResponse(IEnumerable<Gym>? entityList)
        {
            var viewModelList = _mapper.Map<IEnumerable<GymViewModel>>(entityList);
            
            var entityEnumerator = entityList?.GetEnumerator();
            var viewModelEnumerator = viewModelList.GetEnumerator();
            
            var resultList = new List<GymViewModel>();

            while (entityEnumerator.MoveNext())
            {
                while (viewModelEnumerator.MoveNext())
                {
                    if (entityEnumerator.Current.Username == viewModelEnumerator.Current.Username)
                    {
                        resultList.Add(SetUserToken(viewModelEnumerator.Current, entityEnumerator.Current));
                    }
                }
            }
            
            return new ResponseBase<IEnumerable<GymViewModel>>(new ResponseInfo(), resultList);
        }
        
        private void SetGymProperties(Gym entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        private GymViewModel SetUserToken(GymViewModel viewModel, Gym entity)
        {
            viewModel.TokenJWT = authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return viewModel;
        }
    }
}
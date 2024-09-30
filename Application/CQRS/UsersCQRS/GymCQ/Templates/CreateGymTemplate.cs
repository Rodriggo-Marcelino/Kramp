using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.UsersCQRS.GymCQ.DTOs;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Templates
{
    public class CreateGymTemplate : CreateEntityTemplate<
        Gym,
        CreateEntityCommand<Gym, CreateGymDTO, GymViewModel>,
        CreateGymDTO,
        GymViewModel,
        GymRepository>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateGymTemplate(
            GymRepository repository,
            IMapper mapper,
            IAuthService authService) : base(repository, mapper)
        {
            _mapper = mapper;
            _authService = authService;
        }

        protected override void ManipulateEntityBeforeSave(CreateGymDTO data, Gym entity)
        {
            entity.PasswordHash = data.Password;
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        }

        protected override ResponseBase<GymViewModel> CreateResponse(Gym entity)
        {
            var viewModel = _mapper.Map<GymViewModel>(entity);
            viewModel.TokenJWT = _authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return new ResponseBase<GymViewModel>(new ResponseInfo(), viewModel);
        }
    }
}

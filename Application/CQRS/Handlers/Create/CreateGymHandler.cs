using Application.CQRS.Commands.Create;
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

        protected override void ManipulateEntityBeforeSave(CreateGymDTO data, Gym entity)
        {
            entity.PasswordHash = data.Password;
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        protected override ResponseBase<GymViewModel> CreateResponse(Gym entity)
        {
            var viewModel = _mapper.Map<GymViewModel>(entity);
            viewModel.TokenJWT = authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return new ResponseBase<GymViewModel>(new ResponseInfo(), viewModel);
        }
    }
}

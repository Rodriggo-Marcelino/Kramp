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
    public class CreateManagerhandler(
        ManagerRepository repository,
        IMapper mapper,
        IAuthService authService
        ) : CreateEntityTemplate<
                Manager,
                CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>,
                CreateUserDTO,
                UserViewModel,
                ManagerRepository>(repository, mapper)
    {
        private readonly IMapper _mapper = mapper;

        protected override void ManipulateEntityBeforeSave(CreateUserDTO data,
            Manager entity)
        {
            entity.PasswordHash = data.Password;
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        protected override ResponseBase<UserViewModel> CreateResponse(Manager entity)
        {
            var viewModel = _mapper.Map<UserViewModel>(entity);
            viewModel.TokenJWT = authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return new ResponseBase<UserViewModel>(new ResponseInfo(), viewModel);
        }
    }
}
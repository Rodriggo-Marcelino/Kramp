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
    public class CreateProfessionalHandler(
        ProfessionalRepository repository,
        IMapper mapper,
        IAuthService authService
        ) : CreateEntityTemplate<
                Professional,
                CreateEntityCommand<Professional, CreateProfessionalDTO, ProfessionalViewModel>,
                CreateProfessionalDTO,
                ProfessionalViewModel,
                ProfessionalRepository>(repository, mapper)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAuthService _authService = authService;

        protected override void ManipulateEntityBeforeSave(CreateProfessionalDTO data,
            Professional entity)
        {
            entity.PasswordHash = data.Password;
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        protected override ResponseBase<ProfessionalViewModel> CreateResponse(Professional entity)
        {
            var viewModel = _mapper.Map<ProfessionalViewModel>(entity);
            viewModel.TokenJWT = _authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return new ResponseBase<ProfessionalViewModel>(new ResponseInfo(), viewModel);
        }
    }
}

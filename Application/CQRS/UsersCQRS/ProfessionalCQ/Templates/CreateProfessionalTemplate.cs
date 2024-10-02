using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Templates
{
    public class CreateProfessionalTemplate(
        ProfessionalRepository repository,
        IMapper mapper,
        IAuthService authService
        ) : CreateEntityHandler<
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

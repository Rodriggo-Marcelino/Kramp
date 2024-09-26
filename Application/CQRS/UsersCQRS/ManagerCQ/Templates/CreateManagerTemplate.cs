using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ManagerCQ.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class CreateManagerTemplate : CreateEntityTemplate
        <
        Manager,
        CreateManagerCommand,
        ManagerInfoViewModel,
        ManagerRepository,
        CreateUserGenericCommandValidator<
            Manager,
            CreateManagerCommand,
            ManagerInfoViewModel
            >
        >
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public CreateManagerTemplate(
            ManagerRepository repository,
            IMapper mapper,
            IAuthService authService,
            CreateUserGenericCommandValidator<Manager, CreateManagerCommand, ManagerInfoViewModel> validator)
            : base(repository, mapper, validator)
        {
            _mapper = mapper;
            _authService = authService;
        }

        protected override Manager MapCommandToEntity(CreateManagerCommand request)
        {
            Manager manager = base.MapCommandToEntity(request);

            manager.PasswordHash = request.Password;
            manager.CreatedAt = DateTime.UtcNow;
            manager.RefreshToken = Guid.NewGuid().ToString();
            manager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            return manager;
        }

        protected override ResponseBase<ManagerInfoViewModel> CreateResponse(Manager entity)
        {
            var viewModel = _mapper.Map<ManagerInfoViewModel>(entity);
            viewModel.TokenJWT = _authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return new ResponseBase<ManagerInfoViewModel>(new ResponseInfo(), viewModel, viewModel);
        }
    }
}

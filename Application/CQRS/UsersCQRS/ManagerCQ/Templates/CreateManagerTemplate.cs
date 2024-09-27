using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class CreateManagerTemplate : CreateEntityTemplate
        <Manager,
        CreateUserGenericCommand<Manager, UserGenericViewModel>,
        UserGenericViewModel,
        ManagerRepository>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateManagerTemplate(
            ManagerRepository repository,
            IMapper mapper,
            IAuthService authService)
            : base(repository, mapper)
        {
            _mapper = mapper;
            _authService = authService;
        }

        protected override Manager MapCommandToEntity(CreateUserGenericCommand<Manager, UserGenericViewModel> request)
        {
            Manager manager = base.MapCommandToEntity(request);

            manager.PasswordHash = request.Password;
            manager.CreatedAt = DateTime.UtcNow;
            manager.RefreshToken = Guid.NewGuid().ToString();
            manager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            return manager;
        }

        protected override ResponseBase<UserGenericViewModel> CreateResponse(Manager entity)
        {
            var viewModel = _mapper.Map<UserGenericViewModel>(entity);
            viewModel.TokenJWT = _authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return new ResponseBase<UserGenericViewModel>(new ResponseInfo(), viewModel);
        }
    }
}

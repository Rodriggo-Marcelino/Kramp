using Application.CQRS.UsersCQRS.ManagerCQ.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Handlers
{
    public class CreateManagerCommandHandler : CreateEntityTemplate<CreateManagerCommand, Manager, ManagerInfoViewModel, ManagerRepository>
    {
        private readonly IAuthService _authService;
        private readonly ManagerRepository _repository;
        private readonly IMapper _mapper;

        public CreateManagerCommandHandler(ManagerRepository repository, IMapper mapper, IAuthService authService) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _authService = authService;
        }

        protected override Manager CreateEntity(CreateManagerCommand request)
        {
            var manager = base.CreateEntity(request);

            manager.PasswordHash = request.Password;
            manager.CreatedAt = DateTime.UtcNow;
            manager.RefreshToken = Guid.NewGuid().ToString();
            manager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            return manager;
        }

        protected override void ValidateEntity(Manager entity)
        {
            base.ValidateEntity(entity);
        }

        protected override ManagerInfoViewModel ConvertToViewModel(Manager manager)
        {
            var managerInfoVm = base.ConvertToViewModel(manager);
            managerInfoVm.TokenJWT = _authService.GenerateJWT(manager.DocumentNumber!, manager.Username!);
            return managerInfoVm;
        }
    }
}

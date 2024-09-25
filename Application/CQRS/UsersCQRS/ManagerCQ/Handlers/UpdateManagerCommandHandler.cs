using Application.CQRS.UsersCQRS.ManagerCQ.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.User;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Handlers
{
    public class UpdateManagerCommandHandler : IRequestHandler<UpdateManagerCommand, ResponseBase<ManagerInfoViewModel>>
    {
        private readonly ManagerRepository _repository;
        private readonly IMapper _mapper;

        public UpdateManagerCommandHandler(ManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ManagerInfoViewModel>> Handle(UpdateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            Manager? oldManager = await _repository.GetByIdAsync(request.Id);

            if (oldManager == null)
            {
                throw new Exception("Manager not found.");
            }

            Manager newManager = _mapper.Map(request, oldManager);

            newManager.RefreshToken = Guid.NewGuid().ToString();
            newManager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            await _repository.UpdateAsync(newManager);

            ManagerInfoViewModel managerInfoVm = _mapper.Map<ManagerInfoViewModel>(newManager);

            return new ResponseBase<ManagerInfoViewModel>
            {
                ResponseInfo = null,
                Value = managerInfoVm
            };
        }
    }
}

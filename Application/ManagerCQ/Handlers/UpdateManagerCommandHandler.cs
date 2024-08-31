using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
{
    public class UpdateManagerCommandHandler : IRequestHandler<UpdateManagerCommand, ResponseBase<ManagerInfoViewModel>>
    {
        private readonly KrampDbContext _context;
        private readonly IMapper _mapper;

        public UpdateManagerCommandHandler(KrampDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ManagerInfoViewModel>> Handle(UpdateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            Manager oldManager = _context.Managers.FirstOrDefault(manager => manager.Id.Equals(request.Id));

            if (oldManager == null)
            {
                throw new Exception("Manager not found.");
            }

            var newManager = _mapper.Map<Manager>(oldManager);
            newManager = _mapper.Map(request, newManager);
            newManager.RefreshToken = Guid.NewGuid().ToString();
            newManager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            _context.Managers.Update(newManager);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseBase<ManagerInfoViewModel>
            {
                ResponseInfo = null,
                Value = _mapper.Map<ManagerInfoViewModel>(newManager)
            };
        }
    }
}

using Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Handlers
{
    public class CreateProfessionalCommandHandler : IRequestHandler<CreateProfessionalCommand, ResponseBase<ProfessionalInfoViewModel?>>
    {

        private readonly IAuthService _authService;
        private readonly ProfessionalRepository _repository;
        private readonly IMapper _mapper;

        public CreateProfessionalCommandHandler(IAuthService authService, ProfessionalRepository repository, IMapper mapper)
        {
            _authService = authService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ProfessionalInfoViewModel?>> Handle(CreateProfessionalCommand request,
                                                      CancellationToken cancellationToken)
        {
            Professional? professional = _mapper.Map<Professional>(request);
            professional.PasswordHash = request.Data.Password;
            professional.RefreshToken = Guid.NewGuid().ToString();
            professional.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            professional.SetTypeDocument();

            await _repository.AddAsync(professional);

            ProfessionalInfoViewModel professionalInfoVm = _mapper.Map<ProfessionalInfoViewModel>(professional);
            professionalInfoVm.TokenJWT = _authService.GenerateJWT(professional.DocumentNumber!, professional.Username!);

            return new ResponseBase<ProfessionalInfoViewModel?>
            {
                ResponseInfo = null,
                Value = professionalInfoVm
            };
        }


    }
}

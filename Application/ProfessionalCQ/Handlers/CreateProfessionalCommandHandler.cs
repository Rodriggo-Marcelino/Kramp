using Application.ProfessionalCQ.Commands;
using Application.ProfessionalCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using Domain.Entity.Enum;
using Infrastructure.Persistence;
using MediatR;
using Services.Repositories;

namespace Application.ProfessionalCQ.Handlers
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
            professional.PasswordHash = request.Password;
            professional.RefreshToken = Guid.NewGuid().ToString();
            professional.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            professional.setTypeDocument();

            await _repository.AddAsync(professional, cancellationToken);
            
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

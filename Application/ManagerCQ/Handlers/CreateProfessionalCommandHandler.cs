using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Domain.Entity;
using Domain.Entity.Enum;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
{
    public class CreateProfessionalCommandHandler : IRequestHandler<CreateProfessionalCommand, ProfessionalInfoViewModel>
    {

        private readonly KrampDbContext _context;

        public CreateProfessionalCommandHandler(KrampDbContext context)
        {
            _context = context;
        }

        public async Task<ProfessionalInfoViewModel> Handle(CreateProfessionalCommand request,
                                                      CancellationToken cancellationToken)
        {
            var professional = new Professional
            {
                Name = request.Name,
                Surname = request.Surname,
                UserBio = request.UserBio,
                BirthDate = request.BirthDate,
                Username = request.Username,
                PasswordHash = request.Password,
                Job = request.Job,
                DocumentNumber = request.DocumentNumber,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6)
            };

            bool isNutricionist =
                professional.Job is Job.NUTRICIONIST;

            bool isProfessorOrTrainer =
                professional.Job is Job.PERSONAL_TRAINER || professional.Job is Job.GYM_PROFESSOR;

            if (isNutricionist)
            {
                professional.TypeDocument = Document.CRN;
            }
            else if (isProfessorOrTrainer)
            {
                professional.TypeDocument = Document.CREF;
            }
            else
            {
                // TODO: Melhorar na fase de tratamento de exceptions
                throw new Exception();
            }

            _context.Professionals.Add(professional);
            await _context.SaveChangesAsync(cancellationToken);

            return new ProfessionalInfoViewModel
            {
                Name = professional.Name,
                Surname = professional.Surname,
                UserBio = professional.UserBio,
                BirthDate = professional.BirthDate,
                Username = professional.Username,
                Job = professional.Job,
                RefreshToken = professional.RefreshToken,
                RefreshTokenExpiryTime = professional.RefreshTokenExpiryTime,
            };
        }
    }
}

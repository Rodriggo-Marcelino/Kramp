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

        protected override void ManipulateEntityBeforeSave(IEnumerable<CreateProfessionalDTO> request, IEnumerable<Professional> entities)
        {
            foreach (var professional in entities)
            {
                SetProfessionalProperties(professional);
            }
        }

        protected override ResponseBase<IEnumerable<ProfessionalViewModel>> CreateResponse(IEnumerable<Professional>? entityList)
        {
            var viewModelList = _mapper.Map<IEnumerable<ProfessionalViewModel>>(entityList);
            
            var entityEnumerator = entityList?.GetEnumerator();
            var viewModelEnumerator = viewModelList.GetEnumerator();
            
            var resultList = new List<ProfessionalViewModel>();

            while (entityEnumerator.MoveNext())
            {
                while (viewModelEnumerator.MoveNext())
                {
                    if (entityEnumerator.Current.Username == viewModelEnumerator.Current.Username)
                    {
                        resultList.Add(SetUserToken(viewModelEnumerator.Current, entityEnumerator.Current));
                    }
                }
            }
            
            return new ResponseBase<IEnumerable<ProfessionalViewModel>>(new ResponseInfo(), resultList);
        }
        
        private void SetProfessionalProperties(Professional entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        private ProfessionalViewModel SetUserToken(ProfessionalViewModel viewModel, Professional entity)
        {
            viewModel.TokenJWT = authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return viewModel;
        }
    }
}

using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create.User;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create.User
{
    public class CreateManagerHandler(
        ManagerRepository repository,
        IMapper mapper,
        IAuthService authService
        ) : CreateEntityTemplate<
                Manager,
                CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>,
                CreateUserDTO,
                UserViewModel,
                ManagerRepository>(repository, mapper)
    {
        private readonly IMapper _mapper = mapper;

        protected override void ManipulateEntityBeforeSave(IEnumerable<CreateUserDTO> request, IEnumerable<Manager> entities)
        {
            var requests = request.ToList();
            foreach (var manager in entities)
            {
                SetManagerProperties(manager);
            }
        }

        protected override ResponseBase<IEnumerable<UserViewModel>> CreateResponse(IEnumerable<Manager>? entityList)
        {
            var viewModelList = _mapper.Map<IEnumerable<UserViewModel>>(entityList);

            var entities = entityList?.ToList();
            var viewModels = viewModelList.ToList();

            var resultList = new List<UserViewModel>();

            foreach (var entity in entities)
            {
                foreach (var viewModel in viewModels)
                {
                    if (entity.Username == viewModel.Username)
                    {
                        resultList.Add(SetUserToken(viewModel, entity));
                    }
                }
            }

            return new ResponseBase<IEnumerable<UserViewModel>>(new ResponseInfo(), resultList);
        }

        private void SetManagerProperties(Manager entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        private UserViewModel SetUserToken(UserViewModel viewModel, Manager entity)
        {
            viewModel.TokenJWT = authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return viewModel;
        }
    }
}
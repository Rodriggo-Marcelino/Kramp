﻿using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.MemberCQ.Templates
{
    public class CreateMemberTemplate
    (MemberRepository repository, IMapper mapper, IAuthService authService)
        : CreateEntityHandler<
            Member,
            CreateEntityCommand<Member, CreateUserDTO, UserViewModel>,
            CreateUserDTO,
            UserViewModel,
            MemberRepository>(repository, mapper)
    {
        private readonly IMapper _mapper = mapper;

        protected override void ManipulateEntityBeforeSave(IEnumerable<CreateUserDTO> request, IEnumerable<Member> entities)
        {
            foreach (var member in entities)
            {
                SetMemberProperties(member);
            }
        }

        protected override ResponseBase<IEnumerable<UserViewModel>> CreateResponse(IEnumerable<Member>? entityList)
        {
            var viewModelList = _mapper.Map<IEnumerable<UserViewModel>>(entityList);
            
            var entityEnumerator = entityList?.GetEnumerator();
            var viewModelEnumerator = viewModelList.GetEnumerator();
            
            var resultList = new List<UserViewModel>();

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
            
            return new ResponseBase<IEnumerable<UserViewModel>>(new ResponseInfo(), resultList);
        }
        
        private void SetMemberProperties(Member entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }

        private UserViewModel SetUserToken(UserViewModel viewModel, Member entity)
        {
            viewModel.TokenJWT = authService.GenerateJWT(entity.DocumentNumber!, entity.Username!);
            return viewModel;
        }
    }
}

﻿using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.MemberCQ.Templates
{
    public class GetAllMembersTemplate
        (MemberRepository repository, IMapper mapper)
        : GetAllEntitiesTemplate<
            Member,
            GetAllEntitiesQuery<UserViewModel>,
            UserViewModel,
            MemberRepository>(repository, mapper);
}
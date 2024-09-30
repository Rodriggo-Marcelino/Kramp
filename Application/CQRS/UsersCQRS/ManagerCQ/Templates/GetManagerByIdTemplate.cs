﻿using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class GetManagerByIdTemplate
        (ManagerRepository repository, IMapper mapper)
        : GetEntityByIdTemplate<
            Manager,
            GetEntityByIdQuery<UserViewModel>,
            UserViewModel,
            ManagerRepository>(repository, mapper);
}
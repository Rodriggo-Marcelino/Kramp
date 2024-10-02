﻿using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Templates
{
    public class GetAllGymsTemplate
        (GymRepository repository, IMapper mapper)
        : GetAllEntitiesHandler<
            Gym,
            GetAllEntitiesQuery<GymViewModel>,
            GymViewModel,
            GymRepository>(repository, mapper);
}

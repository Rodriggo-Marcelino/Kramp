﻿using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update
{
    public class UpdateManagerHandler
        (ManagerRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
                Manager,
                UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>,
                UpdateUserDTO,
                UserViewModel,
                ManagerRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(IEnumerable<Manager> entities)
        {
            foreach (var entity in entities)
            {
                entity.RefreshToken = Guid.NewGuid().ToString();
                entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            }
        }
    }
}
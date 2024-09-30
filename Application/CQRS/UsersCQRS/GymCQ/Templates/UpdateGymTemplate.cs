using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.UsersCQRS.GymCQ.DTOs;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Templates
{
    public class UpdateGymTemplate
        (GymRepository repository, IMapper mapper)
        : UpdateEntityHandler<
        Gym,
        UpdateEntityCommand<Gym, UpdateGymDTO, GymViewModel>,
        UpdateGymDTO,
        GymViewModel,
        GymRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(Gym entity)
        {
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        }
    }
}

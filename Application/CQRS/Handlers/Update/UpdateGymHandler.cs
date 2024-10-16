using Application.CQRS.Commands.Update;
using Application.CQRS.DTOs.Update;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update
{
    public class UpdateGymHandler
        (GymRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
        Gym,
        UpdateEntityCommand<Gym, UpdateGymDTO, GymViewModel>,
        UpdateGymDTO,
        GymViewModel,
        GymRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(IEnumerable<Gym> entities)
        {
            foreach (var entity in entities)
            {
                entity.RefreshToken = Guid.NewGuid().ToString();
                entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            }
        }
    }
}

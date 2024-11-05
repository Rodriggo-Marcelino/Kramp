using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.User;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.User;

public class UpdateMemberPointsHandler (MemberRepository repository, IMapper mapper)
    : UpdateEntityTemplate<
        Member,
        UpdateEntityCommand<Member, UpdatePointsDTO, UserViewModel>,
        UpdatePointsDTO,
        UserViewModel,
        MemberRepository>(repository, mapper)
{
    
    private readonly MemberRepository _repository;
    private readonly IMapper _mapper;
    
    protected override void ManipulateEntityBeforeUpdate(IEnumerable<Member> entities)
    {
        foreach (var entity in entities)
        {
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        }
    }

    protected override async Task<IEnumerable<Member?>?> UpdateEntityAsync(IEnumerable<Member> entities)
    {
        List<Member> validEntities = new List<Member>();
        entities.ToList();

        foreach (var entity in entities)
        {
            var entityFromDb = await _repository.GetByIdAsync(entity.Id);
            entityFromDb.Points += entity.Points;
            validEntities.Add(entityFromDb);
        }

        if (validEntities.Count > 0)
            return await _repository.UpdateAsync(validEntities);

        return null;
    }
}
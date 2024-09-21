using Application.CQRS.UsersCQRS.MemberCQ.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.User;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.MemberCQ.Handlers;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, ResponseBase<MemberInfoViewModel>>
{
    private readonly MemberRepository _repository;
    private readonly IMapper _mapper;

    public UpdateMemberCommandHandler(MemberRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBase<MemberInfoViewModel>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        Member? oldMember = await _repository.GetByIdAsync(request.Id);

        if (oldMember == null)
        {
            throw new Exception("Member not found.");
        }

        Member newMember = _mapper.Map(request, oldMember);
        newMember.RefreshToken = Guid.NewGuid().ToString();
        newMember.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

        await _repository.UpdateAsync(newMember, cancellationToken);

        MemberInfoViewModel memberInfoVm = _mapper.Map<MemberInfoViewModel>(newMember);

        return new ResponseBase<MemberInfoViewModel>
        {
            ResponseInfo = null,
            Value = memberInfoVm
        };
    }
}
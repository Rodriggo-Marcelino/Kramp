﻿using Application.MemberCQ.Commands;
using Application.MemberCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using MediatR;
using Services.Repositories;

namespace Application.MemberCQ.Handlers
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, ResponseBase<MemberInfoViewModel?>>
    {
        private readonly IAuthService _authService;
        private readonly MemberRepository _repository;
        private readonly IMapper _mapper;

        public CreateMemberCommandHandler(IAuthService authService, MemberRepository repository, IMapper mapper)
        {
            _authService = authService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<MemberInfoViewModel>> Handle(CreateMemberCommand request,
                                                      CancellationToken cancellationToken)
        {
            Member member = _mapper.Map<Member>(request);
            member.PasswordHash = request.Password;
            member.CreatedAt = DateTime.UtcNow;
            member.RefreshToken = Guid.NewGuid().ToString();
            member.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            await _repository.AddAsync(member, cancellationToken);
            
            MemberInfoViewModel memberInfoVm = _mapper.Map<MemberInfoViewModel>(member);
            memberInfoVm.TokenJWT = _authService.GenerateJWT(member.DocumentNumber!, member.Username!);

            return new ResponseBase<MemberInfoViewModel>
            {
                ResponseInfo = null,
                Value = memberInfoVm
            };
        }
    }
}
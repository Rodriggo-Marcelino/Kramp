﻿using Application.GymCQ.Commands;
using Application.GymCQ.ViewModels;
using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.MemberCQ.Commands;
using Application.MemberCQ.ViewModels;
using Application.ProfessionalCQ.Commands;
using Application.ProfessionalCQ.ViewModels;
using AutoMapper;
using Domain.Entity;

namespace Application.Mapping
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<CreateManagerCommand, Manager>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateManagerCommand, Manager>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Manager, ManagerInfoViewModel>().ForMember(x => x.TokenJWT, x=> x.AllowNull());
            
            CreateMap<CreateGymCommand, Gym>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            
            CreateMap<UpdateGymCommand, Gym>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<Gym, GymInfoViewModel>().ForMember(x => x.TokenJWT, x=> x.AllowNull());
            
            CreateMap<CreateMemberCommand, Member>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            
            CreateMap<UpdateMemberCommand, Member>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<Member, MemberInfoViewModel>().ForMember(x => x.TokenJWT, x=> x.AllowNull());
            
            CreateMap<CreateProfessionalCommand, Professional>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<Professional, ProfessionalInfoViewModel>().ForMember(x => x.TokenJWT, x => x.AllowNull());
        }

    }
}

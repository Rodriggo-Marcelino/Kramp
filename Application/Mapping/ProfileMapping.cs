using Application.GymCQ.Commands;
using Application.GymCQ.ViewModels;
using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.MemberCQ.Commands;
using Application.MemberCQ.ViewModels;
using Application.PlanCQ.Commands;
using Application.PlanCQ.ViewModels;
using Application.ProfessionalCQ.Commands;
using Application.ProfessionalCQ.ViewModels;
using Application.WorkoutCQ.Commands;
using Application.WorkoutCQ.ViewModels;
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

            CreateMap<Manager, ManagerInfoViewModel>().ForMember(x => x.TokenJWT, x => x.AllowNull());

            CreateMap<CreateGymCommand, Gym>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateGymCommand, Gym>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Gym, GymInfoViewModel>().ForMember(x => x.TokenJWT, x => x.AllowNull());

            CreateMap<CreateMemberCommand, Member>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateMemberCommand, Member>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Member, MemberInfoViewModel>().ForMember(x => x.TokenJWT, x => x.AllowNull());

            CreateMap<CreateProfessionalCommand, Professional>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateProfessionalCommand, Professional>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Professional, ProfessionalInfoViewModel>().ForMember(x => x.TokenJWT, x => x.AllowNull());

            CreateMap<CreateWorkoutCommand, Workout>().ReverseMap();
            CreateMap<UpdateWorkoutCommand, Workout>().ReverseMap();
            CreateMap<Workout, WorkoutInfoViewModel>().ReverseMap();

            CreateMap<CreatePlanCommand, Plan>().ReverseMap();
            CreateMap<UpdatePlanCommand, Plan>().ReverseMap();
            CreateMap<Plan, PlanInfoViewModel>().ReverseMap();
        }

    }
}

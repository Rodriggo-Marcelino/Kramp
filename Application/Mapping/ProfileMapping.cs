using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.CQRS.UsersCQRS.GymCQ.Commands;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using Application.CQRS.UsersCQRS.ManagerCQ.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;
using Application.CQRS.UsersCQRS.MemberCQ.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Domain.Entity.User;

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

            CreateMap<CreateSimpleWorkoutCommand, Workout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Exercises, opt => opt.Ignore())
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateSimpleWorkoutCommand, Workout>()
                .ForMember(dest => dest.Exercises, opt => opt.Ignore())
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Workout, WorkoutInfoViewModel>()
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CreatePlanCommand, Plan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdatePlanCommand, Plan>()
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Plan, SimplePlanViewModel>().ReverseMap();
        }

    }
}

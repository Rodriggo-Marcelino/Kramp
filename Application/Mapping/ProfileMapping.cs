using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.CQRS.UsersCQRS.GymCQ.DTOs;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
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
            #region Manager Mappings

            CreateMap<CreateUserDTO, Manager>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateUserDTO, Manager>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Manager, UserViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Gym Mappings

            CreateMap<CreateGymDTO, Gym>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateGymDTO, Gym>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Gym, GymViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Member Mappings

            CreateMap<CreateUserDTO, Member>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<CreateUserDTO, Member>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Member, UserViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Professional Mappings

            CreateMap<CreateProfessionalCommand, Professional>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateProfessionalCommand, Professional>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Professional, ProfessionalInfoViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Workout Mappings

            CreateMap<CreateSimpleWorkoutCommand, Workout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Exercises, opt => opt.Ignore())
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateSimpleWorkoutCommand, Workout>()
                .ForMember(dest => dest.Exercises, opt => opt.Ignore())
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Workout, SimpleWorkoutViewModel>()
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CreateCompleteWorkoutCommand, Workout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom(src => src.Exercises))
                .ReverseMap();

            CreateMap<Workout, CompleteWorkoutViewModel>().ReverseMap();

            #endregion

            #region Plan Mappings

            CreateMap<CreateSimplePlanCommand, Plan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateSimplePlanCommand, Plan>()
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Plan, SimplePlanViewModel>().ReverseMap();
            CreateMap<CreateCompletePlanCommand, Plan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Workouts, opt => opt.MapFrom(src => src.Workouts))
                .ReverseMap();

            CreateMap<Plan, CompletePlanViewModel>().ReverseMap();

            #endregion
        }
    }
}
﻿using Application.CQRS.DTOs.Create;
using Application.CQRS.DTOs.Create.Training;
using Application.CQRS.DTOs.Create.User;
using Application.CQRS.DTOs.Update.Training;
using Application.CQRS.DTOs.Update.User;
using Application.CQRS.ViewModels.Training;
using Application.CQRS.ViewModels.User;
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
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(dto => dto.Password));

            CreateMap<UpdateUserDTO, Manager>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Manager, UserViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Gym Mappings

            CreateMap<CreateGymDTO, Gym>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(dto => dto.Password));

            CreateMap<UpdateGymDTO, Gym>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Gym, GymViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Member Mappings

            CreateMap<CreateUserDTO, Member>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(dto => dto.Password));

            CreateMap<UpdateUserDTO, Member>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Member, UserViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Professional Mappings

            CreateMap<CreateProfessionalDTO, Professional>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(dto => dto.Password));

            CreateMap<UpdateProfessionalDTO, Professional>()
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Professional, ProfessionalViewModel>()
                .ForMember(x => x.TokenJWT, x => x.AllowNull());

            #endregion

            #region Plan Mappings

            CreateMap<CreateSimplePlanDTO, Plan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateSimplePlanDTO, Plan>()
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Plan, SimplePlanViewModel>().ReverseMap();

            CreateMap<CreateCompletePlanDTO, Plan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Plan, CompletePlanViewModel>()
                .ForMember(dest => dest.Workouts, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region PlanWorkout Mappings

            CreateMap<AddWorkoutToPlanDTO, PlanWorkout>()
                .ForMember(dest => dest.Plan, opt => opt.Ignore())
                .ForMember(dest => dest.Workout, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PlanWorkoutViewModel, PlanWorkout>()
                .ForMember(dest => dest.Plan, opt => opt.Ignore())
                .ForMember(dest => dest.Workout, opt => opt.Ignore())
                .ReverseMap();
            #endregion

            #region Workout Mappings

            CreateMap<CreateSimpleWorkoutDTO, Workout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Exercises, opt => opt.Ignore())
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateSimpleWorkoutDTO, Workout>()
                .ForMember(dest => dest.Exercises, opt => opt.Ignore())
                .ForMember(dest => dest.TargetedMuscles, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Workout, SimpleWorkoutViewModel>().ReverseMap();

            CreateMap<CreateCompleteWorkoutDTO, Workout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom(src => src.Exercises))
                .ReverseMap();

            CreateMap<Workout, CompleteWorkoutViewModel>().ReverseMap();

            #endregion

            #region WorkoutExercise Mappings
            CreateMap<AddExerciseToWorkoutDTO, WorkoutExercise>()
                .ForMember(dest => dest.Workout, opt => opt.Ignore())
                .ForMember(dest => dest.Exercise, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateExerciseInWorkoutDTO, WorkoutExercise>()
                .ForMember(dest => dest.Workout, opt => opt.Ignore())
                .ForMember(dest => dest.Exercise, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<WorkoutExercise, WorkoutExerciseViewModel>().ReverseMap();
            #endregion

            #region Exercise Mappings

            CreateMap<Exercise, ExerciseViewModel>();
            CreateMap<Exercise, ExerciseSmallViewModel>();

            #endregion

        }
    }
}
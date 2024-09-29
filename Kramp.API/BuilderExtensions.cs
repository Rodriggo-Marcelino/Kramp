﻿using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.UsersCQRS.ManagerCQ.Templates;
using Application.ExceptionHandler;
using Application.Mapping;
using Application.Response;
using Domain.Abstractions;
using Domain.Entity.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.AuthService;
using Services.Repositories;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kramp.API
{
    public static class BuilderExtensions
    {
        public static void AddSwaggerDocs(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Kramp API",
                    Description = "Kramp API",
                    Contact = new OpenApiContact
                    {
                        Name = "Exemplo de pagina de contato",
                        Url = new Uri("https://www.exemplo.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Exemplo de licença",
                        Url = new Uri("https://www.exemplo.com.br")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

        }

        public static void AddJwtAuth(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))

                    };
                });

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddProblemDetails(); //Padrão ProblemDetails para ser usado nas Exceptions
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                typeof(CreateEntityTemplate<Manager, CreateUserCommand<Manager, UserViewModel>, UserViewModel, ManagerRepository>).Assembly));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                typeof(UpdateEntityTemplate<Manager, UpdateUserCommand<Manager, UserViewModel>, UserViewModel, ManagerRepository>).Assembly));
        }
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<KrampDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ProfileMappings).Assembly);
        }

        public static void AddCQRS(this WebApplicationBuilder builder)
        {
            #region Create
            builder.Services.AddScoped(typeof(CreateEntityTemplate<Manager, CreateUserCommand<Manager, UserViewModel>, UserViewModel, ManagerRepository>),
                                       typeof(CreateManagerTemplate));

            builder.Services.AddScoped(typeof(IRequestHandler<CreateUserCommand<Manager, UserViewModel>, ResponseBase<UserViewModel>>),
                                       typeof(CreateManagerTemplate));
            #endregion

            #region GET ALL
            builder.Services.AddScoped<GetAllEntitiesTemplate<Manager, GetAllEntitiesQueryBase<UserViewModel>, UserViewModel, ManagerRepository>,
                                       GetAllManagersTemplate>();

            builder.Services.AddScoped<IRequestHandler<GetAllEntitiesQueryBase<UserViewModel>, ResponseBase<IEnumerable<UserViewModel>>>,
                                       GetAllManagersTemplate>();
            #endregion

            #region GET BY ID
            builder.Services.AddScoped<GetEntityByIdTemplate<Manager, GetEntityByIdQueryBase<UserViewModel>, UserViewModel, ManagerRepository>,
                                       GetManagerByIdTemplate>();

            builder.Services.AddScoped<IRequestHandler<GetEntityByIdQueryBase<UserViewModel>, ResponseBase<UserViewModel>>,
                                       GetManagerByIdTemplate>();
            #endregion

            #region UPDATE
            builder.Services.AddScoped(typeof(UpdateEntityTemplate<Manager, UpdateUserCommand<Manager, UserViewModel>, UserViewModel, ManagerRepository>),
                                       typeof(UpdateManagerTemplate));

            builder.Services.AddScoped(typeof(IRequestHandler<UpdateUserCommand<Manager, UserViewModel>, ResponseBase<UserViewModel>>),
                                       typeof(UpdateManagerTemplate));
            #endregion

            #region DELETE
            builder.Services.AddScoped(typeof(DeleteEntityTemplate<Manager, DeleteEntityCommandBase<Manager>, ManagerRepository>),
                                       typeof(DeleteManagerTemplate));

            builder.Services.AddScoped(typeof(IRequestHandler<DeleteEntityCommandBase<Manager>, Unit>),
                                       typeof(DeleteManagerTemplate));
            #endregion
        }
        public static void AddInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddTransient<ManagerRepository>();
            builder.Services.AddTransient<GymRepository>();
            builder.Services.AddTransient<MemberRepository>();
            builder.Services.AddTransient<ProfessionalRepository>();

            builder.Services.AddTransient<PlanRepository>();
            builder.Services.AddTransient<PlanWorkoutRepository>();
            builder.Services.AddTransient<WorkoutRepository>();
            builder.Services.AddTransient<WorkoutExerciseRepository>();
            builder.Services.AddTransient<ExerciseRepository>();

            builder.Services.AddSingleton<ExceptionHandlingHelper>();

            builder.Services.AddSingleton<ValidatorHelper>();
        }

        public static void AddValidations(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator<Manager, CreateUserCommand<Manager, UserViewModel>, UserViewModel>>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserCommandValidator<Manager, UpdateUserCommand<Manager, UserViewModel>, UserViewModel>>();
            builder.Services.AddFluentValidationAutoValidation();
        }

        public static void AddExceptionHandlers(this WebApplicationBuilder builder)
        {
            // THIS SHOULD BE ON THE BOTTOM, ALWAYS
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }
}

﻿using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.UsersCQRS.ManagerCQ.Templates;
using Application.CQRS.UsersCQRS.ManagerCQ.Validators;
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

            builder.Services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<
                CreateEntityTemplate<Manager, CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>, CreateUserDTO, UserViewModel, ManagerRepository>>()
                );
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
            var services = builder.Services;

            RegisterCQRS<CreateEntityTemplate<Manager, CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>, CreateUserDTO, UserViewModel, ManagerRepository>,
                CreateManagerTemplate,
                CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>,
                UserViewModel>(services);

            RegisterCQRS<UpdateEntityTemplate<Manager, UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>, UpdateUserDTO, UserViewModel, ManagerRepository>,
                UpdateManagerTemplate,
                UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>,
                UserViewModel>(services);

            RegisterVoidCQRS<DeleteEntityTemplate<Manager, DeleteEntityCommand<Manager>, ManagerRepository>,
                DeleteManagerTemplate,
                DeleteEntityCommand<Manager>>(services);

            RegisterCQRS<GetEntityByIdTemplate<Manager, GetEntityByIdQuery<UserViewModel>, UserViewModel, ManagerRepository>,
                GetManagerByIdTemplate,
                GetEntityByIdQuery<UserViewModel>,
                UserViewModel>(services);

            RegisterIEnumerableCQRS<GetAllEntitiesTemplate<Manager, GetAllEntitiesQuery<UserViewModel>, UserViewModel, ManagerRepository>,
                GetAllManagersTemplate,
                GetAllEntitiesQuery<UserViewModel>,
                UserViewModel>(services);
        }

        private static void RegisterCQRS<FromTemplate, ToTemplate, TCommand, TViewModel>(IServiceCollection? services)
            where FromTemplate : IRequestHandler<TCommand, ResponseBase<TViewModel>>
            where ToTemplate : FromTemplate
            where TCommand : IRequest<ResponseBase<TViewModel>>
            where TViewModel : class
        {
            services.AddScoped(typeof(FromTemplate), typeof(ToTemplate));
        }

        private static void RegisterIEnumerableCQRS<FromTemplate, ToTemplate, TCommand, TViewModel>(IServiceCollection? services)
            where FromTemplate : IRequestHandler<TCommand, ResponseBase<IEnumerable<TViewModel>>>
            where ToTemplate : FromTemplate
            where TCommand : IRequest<ResponseBase<IEnumerable<TViewModel>>>
            where TViewModel : class
        {
            services.AddScoped(typeof(FromTemplate), typeof(ToTemplate));
        }

        private static void RegisterVoidCQRS<FromTemplate, ToTemplate, TCommand>(IServiceCollection? services)
            where FromTemplate : IRequestHandler<TCommand, Unit>
            where ToTemplate : FromTemplate
            where TCommand : IRequest<Unit>
        {
            services.AddScoped(typeof(FromTemplate), typeof(ToTemplate));
        }

        public static void AddInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ManagerRepository>();
            builder.Services.AddScoped<GymRepository>();
            builder.Services.AddScoped<MemberRepository>();
            builder.Services.AddScoped<ProfessionalRepository>();

            builder.Services.AddScoped<PlanRepository>();
            builder.Services.AddScoped<PlanWorkoutRepository>();
            builder.Services.AddScoped<WorkoutRepository>();
            builder.Services.AddScoped<WorkoutExerciseRepository>();
            builder.Services.AddScoped<ExerciseRepository>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddSingleton<ExceptionHandlingHelper>();
            builder.Services.AddSingleton<ValidatorHelper>();
        }

        public static void AddValidations(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<CreateManagerCommandValidator>();
            builder.Services.AddFluentValidationAutoValidation();
        }

        public static void AddExceptionHandlers(this WebApplicationBuilder builder)
        {
            // THIS SHOULD BE ON THE BOTTOM, ALWAYS
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }
}

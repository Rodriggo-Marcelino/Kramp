using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.UsersCQRS.ManagerCQ.Templates;
using Application.ExceptionHandler;
using Application.Mapping;
using Application.Response;
using Domain.Abstractions;
using Domain.Entity.User;
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

            void RegisterCQRS<TTemplate, TCommand, TResponse, THandler>()
                where TTemplate : class
                where TCommand : IRequest<TResponse>
                where THandler : class, IRequestHandler<TCommand, TResponse>
            {
                services.AddScoped<TTemplate>();
                services.AddScoped<IRequestHandler<TCommand, TResponse>, THandler>();
            }

            RegisterCQRS<CreateManagerTemplate,
                         CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>,
                         ResponseBase<UserViewModel>,
                         CreateManagerTemplate>();


            RegisterCQRS<GetAllManagersTemplate,
                         GetAllEntitiesQueryBase<UserViewModel>,
                         ResponseBase<IEnumerable<UserViewModel>>,
                         GetAllManagersTemplate>();

            RegisterCQRS<GetManagerByIdTemplate,
                         GetEntityByIdQueryBase<UserViewModel>,
                         ResponseBase<UserViewModel>,
                         GetManagerByIdTemplate>();

            RegisterCQRS<UpdateManagerTemplate,
                         UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>,
                         ResponseBase<UserViewModel>,
                         UpdateManagerTemplate>();

            RegisterCQRS<DeleteManagerTemplate,
                         DeleteEntityCommand<Manager>,
                         Unit,
                         DeleteManagerTemplate>();
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
            builder.Services.AddFluentValidationAutoValidation();
        }

        public static void AddExceptionHandlers(this WebApplicationBuilder builder)
        {
            // THIS SHOULD BE ON THE BOTTOM, ALWAYS
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }
}

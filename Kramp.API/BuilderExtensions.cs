using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
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
                typeof(GetAllEntitiesQueryHandler<Manager, GetAllEntitiesQuery<UserGenericViewModel>, UserGenericViewModel, ManagerRepository>).Assembly));
        }
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<KrampDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddValidations(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUserGenericCommandValidator<Manager, CreateUserGenericCommand<Manager, UserGenericViewModel>, UserGenericViewModel>>();
            builder.Services.AddFluentValidationAutoValidation();
        }

        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ProfileMappings).Assembly);
        }

        public static void AddCQRS(this WebApplicationBuilder builder)
        {
            #region Create
            builder.Services.AddScoped(typeof(CreateEntityTemplate<Manager, CreateUserGenericCommand<Manager, UserGenericViewModel>, UserGenericViewModel, ManagerRepository>),
                                       typeof(CreateManagerTemplate));

            builder.Services.AddScoped(typeof(IRequestHandler<CreateUserGenericCommand<Manager, UserGenericViewModel>, ResponseBase<UserGenericViewModel>>),
                                       typeof(CreateEntityCommandHandler<Manager, CreateUserGenericCommand<Manager, UserGenericViewModel>, UserGenericViewModel, ManagerRepository>));
            #endregion

            #region GET ALL
            builder.Services.AddScoped<GetAllEntitiesTemplate<Manager, GetAllEntitiesQuery<UserGenericViewModel>, UserGenericViewModel, ManagerRepository>,
                GetAllManagersTemplate>();

            builder.Services.AddScoped<IRequestHandler<GetAllEntitiesQuery<UserGenericViewModel>, ResponseBase<IEnumerable<UserGenericViewModel>>>,
                   GetAllEntitiesQueryHandler<Manager, GetAllEntitiesQuery<UserGenericViewModel>, UserGenericViewModel, ManagerRepository>>();
            #endregion

            #region GET BY ID
            builder.Services.AddScoped<GetEntityByIdTemplate<Manager, GetEntityByIdQuery<UserGenericViewModel>, UserGenericViewModel, ManagerRepository>,
                                       GetManagerByIdTemplate>();

            builder.Services.AddScoped<IRequestHandler<GetEntityByIdQuery<UserGenericViewModel>, ResponseBase<UserGenericViewModel>>,
                   GetEntityByIdQueryHandler<Manager, GetEntityByIdQuery<UserGenericViewModel>, UserGenericViewModel, ManagerRepository>>();
            #endregion

            #region UPDATE
            builder.Services.AddScoped(typeof(UpdateEntityTemplate<Manager, UpdateEntityCommand<Manager, UserGenericViewModel>, UserGenericViewModel, ManagerRepository>),
                                       typeof(UpdateManagerTemplate));

            builder.Services.AddScoped(typeof(IRequestHandler<UpdateEntityCommand<Manager, UserGenericViewModel>, ResponseBase<UserGenericViewModel>>),
                                       typeof(UpdateEntityCommandHandler<Manager, UpdateEntityCommand<Manager, UserGenericViewModel>, UserGenericViewModel, ManagerRepository>));
            #endregion
            #region DELETE
            builder.Services.AddScoped(typeof(DeleteEntityTemplate<Manager, DeleteEntityCommand<Manager>, ManagerRepository>),
                                       typeof(DeleteManagerTemplate));

            builder.Services.AddScoped(typeof(IRequestHandler<DeleteEntityCommand<Manager>, Unit>),
                                       typeof(DeleteEntityCommandHandler<Manager, DeleteEntityCommand<Manager>, ManagerRepository>));
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
        }

        public static void AddExceptionHandlers(this WebApplicationBuilder builder)
        {
            // THIS SHOULD BE ON THE BOTTOM, ALWAYS
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }
}

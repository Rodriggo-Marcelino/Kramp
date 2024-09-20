﻿using Application.CQRS.UsersCQRS.ManagerCQ.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.Validators;
using Application.ExceptionHandler;
using Application.Mapping;
using Domain.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.AuthService;
using Services.Repositories;
using System.Reflection;
using System.Text;

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
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateManagerCommand).Assembly));
        }
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<KrampDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // builder.Services.AddEntityFrameworkNpgsql().AddDbContext<KrampDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            // "Server=localhost;Port=5432;Database=kramp;User Id=andrade;Password=Andrade*5432;"
        }

        public static void AddValidations(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<CreateManagerCommandValidator>();
            builder.Services.AddFluentValidationAutoValidation();
        }

        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ProfileMappings).Assembly);
        }
        public static void AddInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddTransient<ManagerRepository>();
            builder.Services.AddTransient<GymRepository>();
            builder.Services.AddTransient<MemberRepository>();
            builder.Services.AddTransient<ProfessionalRepository>();
            builder.Services.AddTransient<ExerciseRepository>();
            builder.Services.AddTransient<WorkoutRepository>();
            builder.Services.AddTransient<PlanRepository>();
            builder.Services.AddSingleton<ExceptionHandlingHelper>();
        }

        public static void AddExceptionHandlers(this WebApplicationBuilder builder)
        {
            // THIS SHOULD BE ON THE BOTTOM, ALWAYS
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }
}

using Application.ManagerCQ.Commands;
using Application.ManagerCQ.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kramp.API
{
    public static class BuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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
    }
}

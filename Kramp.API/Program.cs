using Application.ManagerCQ.Commands;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Application.ManagerCQ.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KrampDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddEntityFrameworkNpgsql().AddDbContext<KrampDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
// "Server=localhost;Port=5432;Database=kramp;User Id=andrade;Password=Andrade*5432;"

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateManagerCommand).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<CreateManagerCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

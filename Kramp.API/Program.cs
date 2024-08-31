using Kramp.API;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.AddServices();
builder.AddDatabase();
builder.AddValidations();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

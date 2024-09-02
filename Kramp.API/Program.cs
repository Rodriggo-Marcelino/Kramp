using Kramp.API;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.AddServices();
builder.AddDatabase();
builder.AddValidations();
builder.AddAutoMapper();
builder.AddSwaggerDocs();
builder.AddJwtAuth();


var app = builder.Build();

// Middleware para servir o arquivo JSON do Swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/swagger/v1/v1_openapi.json"))
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Swagger", "v1_openapi.json");
        var jsonContent = await File.ReadAllTextAsync(filePath);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(jsonContent);
    }
    else
    {
        await next();
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/v1_openapi.json", "Kramp API v1")
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

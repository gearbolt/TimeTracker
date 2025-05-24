using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TimeTracker.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TimeEntriesDbContext>(opt => opt.UseInMemoryDatabase("TimeEntriesDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "Time Tracker API";
    config.Title = "Time Tracker API";
    config.Version = "v1";
    config.Description = "Time Tracker API";
});

var app = builder.Build();
app.UseRouting();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "Time Tracker API";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";    
    });
}

//app.MapGet("/", () => Results.Redirect("/scalar/v1"))
  //  .ExcludeFromDescription();

app.MapTimeEntryRoutes();
app.MapTrainerRoutes();

app.UseHttpsRedirection();

app.Run();

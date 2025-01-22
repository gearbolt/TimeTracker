using Scalar.AspNetCore;
using TimeTracker.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseRouting();


#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapTimeEntryRoutes();
});
#pragma warning restore ASP0014
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.Run();

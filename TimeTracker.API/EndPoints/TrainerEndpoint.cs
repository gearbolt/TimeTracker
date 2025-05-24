using Microsoft.AspNetCore.Http.HttpResults;
using TimeTracker.Shared.Entities;

namespace TimeTracker.API.EndPoints;

public static class TrainerEndpoint
{
    public static IEndpointRouteBuilder MapTrainerRoutes(this IEndpointRouteBuilder routes)
    {
        var trainers = routes.MapGroup("/api/trainers")
            .WithTags("Trainers");
        
        trainers.MapGet("/", async (HttpContext context) =>
        {
            await context.Response.WriteAsJsonAsync(new { Message = "Trainer Pass Endpoint" });
        })
        .WithName("GetTrainers")
        .WithDescription("Returns a list of trainers.");


        trainers.MapGet("/all", () => new { Message = "All route" });

        trainers.MapGet("/smash", () => Results.Ok(new { Message = "Smash route" }));
        
        trainers.MapGet("test", () => Results.Ok(new { Message = "Test route" }));

        trainers.MapGet("/{id}", async ( HttpContext context) =>
        {
            var id = context.Request.RouteValues["id"] as string;
            await context.Response.WriteAsJsonAsync(new { Message = $"Trainer Pass Endpoint with id {id}" });
        });

       
        return routes;
    }
}
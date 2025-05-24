using TimeTracker.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;

namespace TimeTracker.API.EndPoints;

public static class TimeEntryEndpoint
{
    public static IEndpointRouteBuilder MapTimeEntryRoutes(this IEndpointRouteBuilder routes)
    {
        var timeentry = routes.MapGroup("api/TimeEntry").WithTags("TimeEntry");
        //.WithTags(nameof(TimeEntry));
        //timeentry.WithTags("TimeEntry");
        //timeentry.MapGet("/", GetAllTimeEntries);
        timeentry.MapGet("/", GetAllTimeEntries2);        

        timeentry.MapGet("/populate", async (TimeEntriesDbContext db) =>
        {
            await db.Database.EnsureCreatedAsync();
            await db.TimeEntry.AddRangeAsync(
                new TimeEntry { Id = 1, Project = "Time Tracker App", End = DateTime.Now.AddHours(2) },
                new TimeEntry { Id = 2, Project = "Date Picker App", End = DateTime.Now.AddHours(5) }
            );
            await db.SaveChangesAsync();
            return TypedResults.Ok();
        });

        timeentry.MapGet("/{id}", async Task<Results<Ok<TimeEntry>, NotFound>> (int id, TimeEntriesDbContext db) =>
        {
            return await db.TimeEntry.FindAsync(id) switch
            {
                TimeEntry timeEntry => TypedResults.Ok(timeEntry),
                _ => TypedResults.NotFound()
            };
        });

        timeentry.MapPost("/", async (TimeEntryCreateRequest timeEntryRequest, TimeEntriesDbContext db) =>
        {
            var entity = new TimeEntry
            {
                Project = timeEntryRequest.Project,
                Start = timeEntryRequest.Start,
                End = timeEntryRequest.End
            };
            await db.TimeEntry.AddAsync(entity);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/TimeEntry/{entity.Id}", entity);
        });


        timeentry.MapPut("/{id}", async (int id, TimeEntryCreateRequest timeEntryRequest, TimeEntriesDbContext db) =>
        {
            var entity = await db.TimeEntry.FindAsync(id);

            if (entity is null) return TypedResults.NotFound("TimeEntry not found with the given id");

            entity.Project = timeEntryRequest.Project;
            entity.Start = timeEntryRequest.Start;
            entity.End = timeEntryRequest.End;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });


        timeentry.MapDelete("/{id}", async (int id, TimeEntriesDbContext db) =>
        {
            var entity = await db.TimeEntry.FindAsync(id);

            if (entity is null) return TypedResults.NotFound("TimeEntry not found with the given id");

            db.TimeEntry.Remove(entity);
            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        return routes;
    }
    
    
    
    /*
    static async Task<IResult> GetAllTimeEntries()
    {
        //return Results.Ok(_timeEntry);
        await Task.Delay(0);
        return TypedResults.Ok();
    }
    */

    static async Task<List<TimeEntryResponse>> GetAllTimeEntries2(TimeEntriesDbContext db)
    {
        var timeEntries = await db.TimeEntry.ToListAsync();
        return timeEntries.Select(te => new TimeEntryResponse
        {
            Id = te.Id,
            Project = te.Project,
            Start = te.Start,
            End = te.End
        }).ToList();
    }

}
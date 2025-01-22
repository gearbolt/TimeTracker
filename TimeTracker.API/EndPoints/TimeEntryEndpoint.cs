using TimeTracker.Shared.Entities;

namespace TimeTracker.API.EndPoints;

public static class TimeEntryEndpoint
{
    private static List<TimeEntry> _timeEntry =
    [
        new TimeEntry { Id = 1, Project = "Time Tracker App", End = DateTime.Now.AddHours(2) }
    ];
    
    public static void MapTimeEntryRoutes(this IEndpointRouteBuilder routes)
    {
       routes.MapGet("/api/timeentry", async (HttpContext context) =>
       {
           //await context.Response.WriteAsJsonAsync(new { Message = "TimeEntry Pass Endpoint" });
           await context.Response.WriteAsJsonAsync(_timeEntry);
       })
       .WithName("GetTimeEntry")
       .WithOpenApi()
       .WithDescription("Returns a list of time entries.");
       
       routes.MapPost("api/timeentry", async (HttpContext context) =>
       {
           var timeEntry = await context.Request.ReadFromJsonAsync<TimeEntry>();
           if (timeEntry is not null)
           {
               _timeEntry.Add(timeEntry);
           }
           await context.Response.WriteAsJsonAsync(timeEntry);
       });
    }
}
public record struct TimeEntryCreateRequest(
    string Project,
    DateTime Start = default,
    DateTime? End = null
);


/*
public class TimeEntryCreateRequest
{
   public required string Project { get; set; }
   public DateTime Start { get; set; } = DateTime.Now;
   public DateTime? End { get; set; }
}

*/
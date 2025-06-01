using TimeTracker.Shared.Entities;

public class Project : SoftDeleteableEntity
{
    public required string Name { get; set; }

    public List<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();

    public ProjectDetails? Details { get; set; }
    
    public List<User> Users { get; set; } = new List<User>();

/*
                    // Navigation properties
                    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

                    */
}
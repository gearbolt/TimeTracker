namespace TimeTracker.Shared.Entities;

public class TimeEntry : BaseEntity
{
    public int? ProjectId { get; set; }
    public required Project Project { get; set; }
    public DateTime Start {get; set;} = DateTime.Now;
    public DateTime? End {get; set;}

    //public DateTime DateCreated {get; set;} = DateTime.Now;
    // public DateTime? DateUpdated {get; set;} 
}
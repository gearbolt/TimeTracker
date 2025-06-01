public class ProjectDetails
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }

    public int ProjectId { get; set; }
    public required Project Project { get; set; }
}
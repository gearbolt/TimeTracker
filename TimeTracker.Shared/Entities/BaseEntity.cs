public class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public DateTime DateUpdated { get; set; } = DateTime.Now;

    // Override ToString() for better debugging and logging
    /*
    public override string ToString()
    {
        return $"{GetType().Name} (Id: {Id}, DateCreated: {DateCreated})";
    }
    */
}
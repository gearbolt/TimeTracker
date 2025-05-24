using Microsoft.EntityFrameworkCore;
using TimeTracker.Shared.Entities;

class TimeEntriesDbContext : DbContext
{
    public TimeEntriesDbContext(DbContextOptions<TimeEntriesDbContext> options)
     : base(options){}

    //public DbSet<TimeEntry> TimeEntry { get; set; } = null!;
    public DbSet<TimeEntry> TimeEntry => Set<TimeEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
            modelBuilder.Entity<TimeEntry>().HasData(
            new TimeEntry { Id = 1, Project = "Time Tracker App", End = DateTime.Now.AddHours(2) },
            new TimeEntry { Id = 2, Project = "Date Picker App", End = DateTime.Now.AddHours(5) }
        
        );
        */
    }
}
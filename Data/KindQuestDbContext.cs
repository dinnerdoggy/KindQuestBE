using KindQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace KindQuest.Data
{

  public class KindQuestDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Job> Jobs { get; set; }

    public KindQuestDbContext(DbContextOptions<KindQuestDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Configure many-to-many: User <-> Project
      modelBuilder.Entity<User>()
          .HasMany(u => u.Projects)
          .WithMany(p => p.Volunteers);

      // Seed Users
      modelBuilder.Entity<User>().HasData(
          new User { Id = 1, Uid = "abc123", FirstName = "Alex", LastName = "Smith", Email = "alex@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/alex.jpg" }
      );

      // Seed Projects
      modelBuilder.Entity<Project>().HasData(
          new Project { Id = 1, UserId = 1, ProjectName = "Neighborhood Cleanup", ProjectDescription = "Help clean up the local park.", DatePosted = DateTime.Today, DateCompleted = DateTime.Today.AddDays(5), IsCompleted = false, Location = "Central Park", ProjectImg = "https://example.com/cleanup.jpg", JobList = "Collect trash,Trim bushes" }
      );

      // Seed Jobs
      modelBuilder.Entity<Job>().HasData(
          new Job { Id = 1, ProjectId = 1, UserId = 1, JobName = "Pick up trash", JobDescription = "Collect litter from the ground.", DatePosted = DateTime.Today, DateCompleted = DateTime.Today.AddDays(1), IsCompleted = false }
      );
    }
  }
}

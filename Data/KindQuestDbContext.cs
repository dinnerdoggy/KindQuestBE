using KindQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace KindQuest.Data;

  public class KindQuestDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Job> Jobs { get; set; }

    public KindQuestDbContext(DbContextOptions<KindQuestDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-Many: User (creator) -> Projects
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Creator)
            .WithMany(u => u.CreatedProjects)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Many-to-Many: Users <-> Projects (volunteers)
        modelBuilder.Entity<User>()
            .HasMany(u => u.VolunteeredProjects)
            .WithMany(p => p.Volunteers)
            .UsingEntity(j => j.ToTable("UserProjects"));

        // One-to-Many: User -> Jobs
        modelBuilder.Entity<Job>()
            .HasOne(j => j.User)
            .WithMany(u => u.Jobs)
            .HasForeignKey(j => j.UserId);

        // One-to-Many: Project -> Jobs
        modelBuilder.Entity<Job>()
            .HasOne(j => j.Project)
            .WithMany(p => p.Jobs)
            .HasForeignKey(j => j.ProjectId);

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Uid = "abc123", FirstName = "Alex", LastName = "Smith", Email = "alex@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/alex.jpg" }
        );

        // Seed Projects
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, UserId = 1, ProjectName = "Neighborhood Cleanup", ProjectDescription = "Help clean up the local park.", DatePosted = DateTime.UtcNow, DateCompleted = DateTime.UtcNow.AddDays(5), IsCompleted = false, Location = "Central Park", ProjectImg = "https://example.com/cleanup.jpg" }
        );

        // Seed Jobs
        modelBuilder.Entity<Job>().HasData(
            new Job { Id = 1, ProjectId = 1, UserId = 1, JobName = "Pick up trash", JobDescription = "Collect litter from the ground.", DatePosted = DateTime.UtcNow, DateCompleted = DateTime.UtcNow.AddDays(1), IsCompleted = false }
        );
    }
  }


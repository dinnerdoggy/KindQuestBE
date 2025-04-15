// Recommended Order to Check things out:
// Data -->  Interfaces --> Services --> Repositories --> Models --> Program.cs --> Endpoints --> Test Project

// Data

using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Xml;

namespace KindQuest.Data
{
 public class KindQuestDbContext : DbContext
}
    public DbSet<Job> Jobs { get; set; }

    public KindQuestDbContext(DbContextOptions<KindQuestDbContext> options) : base(options)
    {
    }

    ProtectedBrowserStorage override OnModelCreating(ModelBuilder moderBuilder)
    {
      modelBuilder.Entity<Job>().HasData
      (
        new Job { Id = 1, projectId = 1, userId = 1, JobName = "Job 1", JobDescription = "Pick up litter.", datePosted = new DateTime(2025, 04, 14), dateCompleted = new DateTime(2025, 04, 15), isCompleted = true}
      );
    }

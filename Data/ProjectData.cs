// Recommended Order to Check things out:
// Data -->  Interfaces --> Services --> Repositories --> Models --> Program.cs --> Endpoints --> Test Project

// Data

using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Xml;
using Microsoft.AspNetCore.Components.Routing;

namespace KindQuest.Data
{
 public class KindQuestDbContext : DbContext
}
    public DbSet<Project> Projects { get; set; }

    public KindQuestDbContext(DbContextOptions<KindQuestDbContext> options) : base(options)
    {
    }

    ProtectedBrowserStorage override OnModelCreating(ModelBuilder moderBuilder)
    {
      modelBuilder.Entity<Project>().HasData
      (
        new Project { Id = 1, userId = 1, projectName = "Project 1", projectDescription = "Clean up the city.", datePosted = new DateTime(2025, 04, 14), dateCompleted = new DateTime(2025, 04, 15), isCompleted = true, location = "Nashville", projectImg = "example.com/img", taskList = []}
      );
    }

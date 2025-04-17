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
    public DbSet<User> Users { get; set; }

    public KindQuestDbContext(DbContextOptions<KindQuestDbContext> options) : base(options)
    {
    }

    ProtectedBrowserStorage override OnModelCreating(ModelBuilder moderBuilder)
    {
      modelBuilder.Entity<User>().HasData
      (
        new User { Id = 1, uId = "abc", firstName = "John", lastName = "Doe", email = "test@example.com", emergencyContact = 8675309, profilePic = "examplelink.com/image"}
      );
    }

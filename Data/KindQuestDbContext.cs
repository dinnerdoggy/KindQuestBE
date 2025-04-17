using Microsoft.EntityFrameworkCore;
using KindQuest.Models;

namespace KindQuest.Data;

  public class KindQuestDbContext : DbContext
{
  public DbSet<Project> Projects { get; set; }
  public DbSet<Job> Jobs { get; set; }
  public DbSet<User> Users { get; set; }

  public KindQuestDbContext(DbContextOptions<KindQuestDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Project>().HasData(
    // Data goes here
    );
    modelBuilder.Entity<Job>().HasData(
    // Data goes here
    );
    modelBuilder.Entity<User>().HasData(
    // Data goes here
    );


  }
}

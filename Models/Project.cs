namespace KindQuest.Models;

public class Project
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? ProjectName { get; set; }
    public string? ProjectDescription { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime DateCompleted { get; set; }
    public bool IsCompleted { get; set; }
    public string Location { get; set; }
    public string ProjectImg { get; set; }
    public string JobList { get; set; }

<<<<<<< HEAD
    public User? Creator { get; set; }
    public List<User>? Volunteers { get; set; }
    public List<Job>? Jobs { get; set; }
=======
    public User User { get; set; }
    public List<User> Volunteers { get; set; }
    public List<Job> Jobs { get; set; }
>>>>>>> 93f14f79531ce93b1ae285c955913a3a2a1a1297
}

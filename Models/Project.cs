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
    public string? Location { get; set; }
    public string? ProjectImg { get; set; }
    public string? TaskList { get; set; }

    public User? Creator { get; set; }
    public List<User>? Volunteers { get; set; }
    public List<Job>? Jobs { get; set; }
}

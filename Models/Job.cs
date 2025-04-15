namespace KindQuest.Models;

public class Job
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public string JobName { get; set; }
    public string JobDescription { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime DateCompleted { get; set; }
    public bool IsCompleted { get; set; }

    public Project Project { get; set; }
    public User User { get; set; }
}

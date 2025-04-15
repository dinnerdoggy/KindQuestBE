namespace KindQuestBE.Models;

public class Task
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime DateCompleted { get; set; }
    public bool IsCompleted { get; set; }

    public Project Project { get; set; }
    public User User { get; set; }
}

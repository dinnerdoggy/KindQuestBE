namespace KindQuest.Models;
    public class User
{
    public int Id { get; set; }
    public string Uid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public long EmergencyContact { get; set; }
    public string ProfilePic { get; set; }

    public List<Project> Projects { get; set; }
    public List<Job> Jobs { get; set; }
}

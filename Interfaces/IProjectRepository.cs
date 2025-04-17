// Interfaces - Repository

using KindQuest.Models;

namespace KindQuest.Interfaces
{
  public interface IProjectRepository
  {
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(int id);
    Task<Project> CreateAsync(Project project);
    Task<Project> UpdateAsync(int id, Project project);
    Task<bool> DeleteAsync(int id);
   }
}

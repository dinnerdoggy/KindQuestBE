// Interfaces - Repository

using KindQuest.Models;

namespace KindQuest.Interfaces
{
  public interface IJobRepository
  {
    Task<IEnumerable<Job>> GetAllAsync();
        Task<Job> GetByIdAsync(int id);
        Task<Job> CreateAsync(Job job);
        Task<Job> UpdateAsync(int id, Job job);
        Task<bool> DeleteAsync(int id);
    }
}

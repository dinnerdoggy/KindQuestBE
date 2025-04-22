using KindQuest.Interfaces;
using KindQuest.Models;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository) => _jobRepository = jobRepository;


    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await _jobRepository.GetAllAsync();
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        return await _jobRepository.GetByIdAsync(id);
    }

    public async Task<Job> CreateAsync(Job job)
    {
        return await _jobRepository.CreateAsync(job);
    }

    public async Task<Job?> UpdateAsync(int id, Job job)
    {
        return await _jobRepository.UpdateAsync(id, job);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _jobRepository.DeleteAsync(id);
    }
}

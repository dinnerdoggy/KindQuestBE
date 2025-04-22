<<<<<<< HEAD
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
=======
using KindQuest.Models;
using KindQuest.Repositories;
using KindQuest.Interfaces;
using KindQuest.Data;
using Microsoft.EntityFrameworkCore;
namespace KindQuest.Services
{
    public class JobService : IJobRepository
    {
        private readonly KindQuestDbContext _context;
        public JobService(KindQuestDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync();
        }
        public async Task<Job> GetByIdAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }
        public async Task<Job> CreateAsync(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }
        public async Task<Job> UpdateAsync(int id, Job job)
        {
            var existingJob = await _context.Jobs.FindAsync(id);
            if (existingJob == null)
            {
                return null;
            }
            existingJob.JobName = job.JobName;
            existingJob.JobDescription = job.JobDescription;
            existingJob.DatePosted = job.DatePosted;
            existingJob.DateCompleted = job.DateCompleted;
            existingJob.IsCompleted = job.IsCompleted;
            await _context.SaveChangesAsync();
            return existingJob;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return false;
            }
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
>>>>>>> 93f14f79531ce93b1ae285c955913a3a2a1a1297

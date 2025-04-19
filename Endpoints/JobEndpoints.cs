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
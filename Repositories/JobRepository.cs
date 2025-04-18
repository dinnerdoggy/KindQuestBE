using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;

namespace KindQuest.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly KindQuestDbContext _context;

        public JobRepository(KindQuestDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Job> CreateAsync(Job job)
        {
            throw new NotImplementedException();
        }

        public Task<Job> UpdateAsync(int id, Job job)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

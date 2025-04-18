using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;

namespace KindQuest.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly KindQuestDbContext _context;

        public ProjectRepository(KindQuestDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> CreateAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(int id, Project project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

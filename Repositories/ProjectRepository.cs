using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;

namespace KindQuest.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly KindQuestDbContext _context;
        public ProjectRepository(KindQuestDbContext context) => _context = context;

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task<Project> CreateAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<Project> UpdateAsync(int id, Project project)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return null;
            }
            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            await _context.SaveChangesAsync();
            return existingProject;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
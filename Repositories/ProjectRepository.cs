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
            if (id <= 0)
            {
                return (Project)Results.BadRequest("Id not found");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return (Project)Results.BadRequest("Project not found");
            }
            return project;
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
                return (Project)Results.BadRequest("Project not found");
            }
            existingProject.ProjectName = project.ProjectName;
            existingProject.ProjectDescription = project.ProjectDescription;
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
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
            if (string.IsNullOrEmpty(project.CreatorUid))
            {
                throw new ArgumentException("CreatorUid cannot be null or empty.", nameof(project.CreatorUid));
            }

            var existingUser = await _context.Users.AnyAsync(u => u.Uid == project.CreatorUid);
            if (!existingUser)
            {
                throw new InvalidOperationException($"User with Uid '{project.CreatorUid}' does not exist.");
            }

            
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<Project> UpdateAsync(int id, Project project)
        {
            var existingProject = await _context.Projects
           .Include(p => p.Volunteers)
           .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProject == null)
            {
                return (Project)Results.BadRequest("Project not found");
            }
            if (project == null)
            {
                return (Project)Results.BadRequest("Project cannot be null");
            }
            if (project.Volunteers != null && project.Volunteers.Any())
            {
                var volunteerIds = project.Volunteers.Select(v => v.Id).ToList();
                var volunteers = await _context.Users
                    .Where(u => volunteerIds.Contains(u.Id))
                    .AsNoTracking()
                    .ToListAsync();

                _context.Entry(existingProject).Collection(p => p.Volunteers).Load();
                existingProject.Volunteers.Clear();

                foreach (var volunteer in volunteers)
                {
                    _context.Attach(volunteer); // Explicitly attach the volunteer to avoid duplicate tracking
                    existingProject.Volunteers.Add(volunteer);
                }
            }

            existingProject.Uid = project.Uid;
            existingProject.ProjectName = project.ProjectName;
            existingProject.ProjectDescription = project.ProjectDescription;
            existingProject.DatePosted = project.DatePosted;
            existingProject.DateCompleted = project.DateCompleted;
            existingProject.IsCompleted = project.IsCompleted;
            existingProject.Location = project.Location;
            existingProject.ProjectImg = project.ProjectImg;
            existingProject.Creator = project.Creator;
            existingProject.Jobs = project.Jobs;
            _context.Projects.Update(existingProject);
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
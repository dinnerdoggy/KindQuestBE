using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuest.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository) => _projectRepository = projectRepository;

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return (Project)Results.BadRequest("Id not found");
            }
<<<<<<< HEAD
            var project = await _projectRepository.GetByIdAsync(id);    
=======
            existingProject.ProjectName = project.ProjectName;
            existingProject.ProjectDescription = project.ProjectDescription;
            existingProject.DatePosted = project.DatePosted;
            existingProject.DateCompleted = project.DateCompleted;
            await _context.SaveChangesAsync();
            return existingProject;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
>>>>>>> 93f14f79531ce93b1ae285c955913a3a2a1a1297
            if (project == null)
            {
                return (Project)Results.BadRequest("Project not found");
            }
            return project;
        }

        public async Task<Project> CreateAsync(Project project)
        {
             
            return await _projectRepository.CreateAsync(project);
        }

        public async Task<Project> UpdateAsync(int id, Project project)
        {
              
            return await _projectRepository.UpdateAsync(id, project);
        }

        public async Task<bool> DeleteAsync(int id)
        {
              
            return await _projectRepository.DeleteAsync(id);
        }
    }
}

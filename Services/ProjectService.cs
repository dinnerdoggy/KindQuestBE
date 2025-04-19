using KindQuest.Models;
using Microsoft.EntityFrameworkCore;
using KindQuest.Interfaces;
using KindQuest.Data;

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
            var project = await _projectRepository.GetByIdAsync(id); // Fixed the incorrect usage of FindAsync    
            if (project == null)
            {
                return (Project)Results.BadRequest("Project not found");
            }
            return project;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            // FIX: Use the CreateAsync method from IProjectRepository instead of accessing a non-existent 'Projects' property  
            return await _projectRepository.CreateAsync(project);
        }

        public async Task<Project> UpdateAsync(int id, Project project)
        {
            // FIX: Use the UpdateAsync method from IProjectRepository instead of accessing a non-existent 'Projects' property  
            return await _projectRepository.UpdateAsync(id, project);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // FIX: Use the DeleteAsync method from IProjectRepository instead of accessing a non-existent 'Projects' property  
            return await _projectRepository.DeleteAsync(id);
        }
    }
}

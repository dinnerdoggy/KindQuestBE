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

        public async Task<Project?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return null;
            }
            return project;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            var createdProject = await _projectRepository.CreateAsync(project);
            return createdProject; // Ensure the created project is returned
        }


        public async Task<Project?> UpdateAsync(int id, Project project)
        {
            return await _projectRepository.UpdateAsync(id, project);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _projectRepository.DeleteAsync(id);
        }
    }
}

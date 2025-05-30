using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuest.EndPoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
        {
            // Get all projects  
            routes.MapGet("/projects", async (IProjectService repo) =>
            {
                return await repo.GetAllAsync();
            });

            // Get project by id
            routes.MapGet("/projects/{id}", async (IProjectService repo, int id) =>
            {
                var project = await repo.GetByIdAsync(id);
                if (project != null)
                {
                    return Results.Ok(project);
                }
                return Results.NotFound($"Project with id {id} not found.");
            });


            // Create new project  
            routes.MapPost("/projects", async (IProjectService repo, Project project) =>
            {
                if (project == null)
                {
                    return Results.BadRequest("Project cannot be null.");
                }

                if (string.IsNullOrEmpty(project.CreatorUid))
                {
                    return Results.BadRequest("CreatorUid cannot be null or empty.");
                }
                var createdProject = await repo.CreateAsync(project);
                return Results.Json(createdProject);
            });

            // Update project by id
            routes.MapPut("/projects/{id}", async (IProjectService repo, int id, Project project) =>
            {
                if (project == null)
                {
                    return Results.BadRequest("Project cannot be null.");
                }
                var updatedProject = await repo.UpdateAsync(id, project);
                if (updatedProject != null)
                {
                    updatedProject.Id = id;
                    updatedProject.Uid = project.Uid;
                    updatedProject.ProjectName = project.ProjectName;
                    updatedProject.ProjectDescription = project.ProjectDescription;
                    updatedProject.DatePosted = project.DatePosted;
                    updatedProject.DateCompleted = project.DateCompleted;
                    updatedProject.IsCompleted = project.IsCompleted;
                    updatedProject.Location = project.Location;
                    updatedProject.ProjectImg = project.ProjectImg;
                    updatedProject.Creator = project.Creator;
                    updatedProject.Volunteers = project.Volunteers;
                    updatedProject.Jobs = project.Jobs;

                    return Results.Ok(updatedProject);
                }
                return Results.NotFound($"Project with id {id} not found.");
            });

            // Delete project by id
            routes.MapDelete("/projects/{id}", async (IProjectService repo, int id) =>
            {
                var deleted = await repo.DeleteAsync(id);
                if (deleted)
                {
                    return Results.NoContent();
                }
                return Results.NotFound($"Project with id {id} not found.");
            });

        }
    }
}

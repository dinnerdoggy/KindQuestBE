using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuest.EndPoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/projects", async (IProjectRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllProjects")
            .Produces<List<Project>>(StatusCodes.Status200OK);
            routes.MapGet("/projects/{id}", async (IProjectRepository repo, int id) =>
            {
                return await repo.GetByIdAsync(id);
            })
            .WithName("GetProjectById")
            .Produces<Project>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapPost("/projects", async (IProjectRepository repo, Project project) =>
            {
                return await repo.CreateAsync(project);
            })
            .WithName("CreateProject")
            .Produces<Project>(StatusCodes.Status201Created);
            routes.MapPut("/projects/{id}", async (IProjectRepository repo, int id, Project project) =>
            {
                return await repo.UpdateAsync(id, project);
            })
            .WithName("UpdateProject")
            .Produces<Project>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapDelete("/projects/{id}", async (IProjectRepository repo, int id) =>
            {
                return await repo.DeleteAsync(id);
            })
            .WithName("DeleteProject")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}

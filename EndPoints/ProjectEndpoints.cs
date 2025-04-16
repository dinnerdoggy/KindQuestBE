using KindQuestBE.Models;
using KindQuestBE.Repositories.Interfaces;

namespace KindQuestBE.EndPoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/projects", async (IProjectRepository repo) =>
            {
                return await repo.GetAllProjects();
            })
            .WithName("GetAllProjects")
            .Produces<List<Project>>(StatusCodes.Status200OK);
            routes.MapGet("/projects/{id}", async (IProjectRepository repo, int id) =>
            {
                return await repo.GetProjectById(id);
            })
            .WithName("GetProjectById")
            .Produces<Project>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapPost("/projects", async (IProjectRepository repo, Project project) =>
            {
                return await repo.CreateProject(project);
            })
            .WithName("CreateProject")
            .Produces<Project>(StatusCodes.Status201Created);
            routes.MapPut("/projects/{id}", async (IProjectRepository repo, int id, Project project) =>
            {
                return await repo.UpdateProject(id, project);
            })
            .WithName("UpdateProject")
            .Produces<Project>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapDelete("/projects/{id}", async (IProjectRepository repo, int id) =>
            {
                return await repo.DeleteProject(id);
            })
            .WithName("DeleteProject")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}

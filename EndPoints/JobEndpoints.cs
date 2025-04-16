using KindQuestBE.Models;
using KindQuestBE.Repositories.Interfaces;

namespace KindQuestBE.EndPoints
{
    public static class JobEndpoints
    {
        public static void MapJobEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/jobs", async (IJobRepository repo) =>
            {
                return await repo.GetAllJobs();
            })
            .WithName("GetAllJobs")
            .Produces<List<Job>>(StatusCodes.Status200OK);
            routes.MapGet("/jobs/{id}", async (IJobRepository repo, int id) =>
            {
                return await repo.GetJobById(id);
            })
            .WithName("GetJobById")
            .Produces<Job>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapPost("/jobs", async (IJobRepository repo, Job job) =>
            {
                return await repo.CreateJob(job);
            })
            .WithName("CreateJob")
            .Produces<Job>(StatusCodes.Status201Created);
            routes.MapPut("/jobs/{id}", async (IJobRepository repo, int id, Job job) =>
            {
                return await repo.UpdateJob(id, job);
            })
            .WithName("UpdateJob")
            .Produces<Job>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapDelete("/jobs/{id}", async (IJobRepository repo, int id) =>
            {
                return await repo.DeleteJob(id);
            })
            .WithName("DeleteJob")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}

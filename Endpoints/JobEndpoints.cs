using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuest.EndPoints
{
    public static class JobEndpoints
    {
        public static void MapJobEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/jobs", async (IJobRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllJobs")
            .Produces<List<Job>>(StatusCodes.Status200OK);

            routes.MapGet("/jobs/{id}", async (IJobRepository repo, int id) =>
            {
                var job = await repo.GetByIdAsync(id);
                return job is not null ? Results.Ok(job) : Results.NotFound();
            })
            .WithName("GetJobById")
            .Produces<Job>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapPost("/jobs", async (IJobRepository repo, Job job) =>
            {
                var created = await repo.CreateAsync(job);
                return Results.Created($"/jobs/{created.Id}", created);
            })
            .WithName("CreateJob")
            .Produces<Job>(StatusCodes.Status201Created);

            routes.MapPut("/jobs/{id}", async (IJobRepository repo, int id, Job job) =>
            {
                var updated = await repo.UpdateAsync(id, job);
                return updated is not null ? Results.Ok(updated) : Results.NotFound();
            })
            .WithName("UpdateJob")
            .Produces<Job>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapDelete("/jobs/{id}", async (IJobRepository repo, int id) =>
            {
                var success = await repo.DeleteAsync(id);
                return success ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteJob")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}

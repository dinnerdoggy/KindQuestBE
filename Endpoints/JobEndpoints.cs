using KindQuest.Interfaces;
using KindQuest.Models;

namespace KindQuest.Endpoints;

public static class JobEndpoints
{
    public static void MapJobEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/jobs").WithTags("Jobs");
        group.MapGet("/", async (IJobRepository jobService) =>
        {
            return await jobService.GetAllAsync();
        })
        .WithName("GetAllJobs")
        .Produces<List<Job>>(StatusCodes.Status200OK);
        group.MapGet("/{id}", async (int id, IJobRepository jobService) =>
        {
            return await jobService.GetByIdAsync(id);
        })
        .WithName("GetJobById")
        .Produces<Job>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        group.MapPost("/", async (Job job, IJobRepository jobService) =>
        {
            return await jobService.CreateAsync(job);
        });
        group.MapPut("/{id}", async (int id, Job job, IJobRepository jobService) =>
        {
            return await jobService.UpdateAsync(id, job);
        });
        group.MapDelete("/{id}", async (int id, IJobRepository jobService) =>
        {
            return await jobService.DeleteAsync(id);
        });
    }
}
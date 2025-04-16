using KindQuestBE.Models;
using KindQuestBE.Repositories.Interfaces;

namespace KindQuestBE.EndPoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/users", async (IUserRepository repo) =>
            {
                return await repo.GetAllUsers();
            })
            .WithName("GetAllUsers")
            .Produces<List<User>>(StatusCodes.Status200OK);
            routes.MapGet("/users/{id}", async (IUserRepository repo, int id) =>
            {
                return await repo.GetUserById(id);
            })
            .WithName("GetUserById")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapPost("/users", async (IUserRepository repo, User user) =>
            {
                return await repo.CreateUser(user);
            })
            .WithName("CreateUser")
            .Produces<User>(StatusCodes.Status201Created);
            routes.MapPut("/users/{id}", async (IUserRepository repo, int id, User user) =>
            {
                return await repo.UpdateUser(id, user);
            })
            .WithName("UpdateUser")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            routes.MapDelete("/users/{id}", async (IUserRepository repo, int id) =>
            {
                return await repo.DeleteUser(id);
            })
            .WithName("DeleteUser")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}

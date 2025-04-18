using KindQuest.Interfaces;
using KindQuest.Models;

namespace KindQuest.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/users").WithTags("Users");
        group.MapGet("/", async (IUserRepository userService) =>
        {
            return await userService.GetAllUsers();
        })
        .WithName("GetAllUsers")
        .Produces<List<User>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUserRepository userService) =>
        {
            return await userService.GetUserById(id);
        })
        .WithName("GetUserById")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (User user, IUserRepository userService) =>
        {
            return await userService.CreateUser(user);
        });

        group.MapPut("/{id}", async (int id, User user, IUserRepository userService) =>
        {
            return await userService.UpdateUser(id, user);
        });

        group.MapDelete("/{id}", async (int id, IUserRepository userService) =>
        {
            return await userService.DeleteUser(id);
        });

    }
}
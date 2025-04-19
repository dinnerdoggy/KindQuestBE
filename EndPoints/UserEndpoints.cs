using KindQuest.Interfaces;
using KindQuest.Models;

namespace KindQuest.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/users").WithTags("Users");
        group.MapGet("/", async (IUserService userService) =>
        {
            return await userService.GetAllUsersAsync();
        })
        .WithName("GetAllUsers")
        .Produces<List<User>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUserService userService) =>
        {
            return await userService.GetUserByIdAsync(id);
        })
        .WithName("GetUserById")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (User user, IUserService userService) =>
        {
            return await userService.CreateUserAsync(user);
        });

        group.MapPut("/{id}", async (int id, User user, IUserService userService) =>
        {
            // Fix: Update the call to match the correct method signature  
            user.Id = id;
            return await userService.UpdateUserAsync(user);
        });

        group.MapDelete("/{id}", async (int id, IUserService userService) =>
        {
            await userService.DeleteUserAsync(id);
            return Results.NoContent();
        });
    }
}

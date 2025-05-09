using KindQuest.Interfaces;
using KindQuest.Models;

namespace KindQuest.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        // Get All Users
        routes.MapGet("/users", async (IUserService repo) =>
        {
            return await repo.GetAllUsersAsync();
        })
        .WithName("GetAllUsers")
        .Produces<List<User>>(StatusCodes.Status200OK);

        // Get User By Id
        routes.MapGet("/users/{id}", async (int id, IUserService repo) =>
        {
            var user = await repo.GetUserByIdAsync(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        })
        .WithName("GetUserById")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // Create User
        routes.MapPost("/users", async (User user, IUserService repo) =>
        {
            var createdUser = await repo.CreateUserAsync(user); 
            return Results.Created($"/api/users/{createdUser.Id}", createdUser);
        })
        .WithName("CreateUser")
        .Produces<User>(StatusCodes.Status201Created);

        // Update User
        routes.MapPut("/users/{id}", async (int id, User user, IUserService repo) =>
        {
            var updatedUser = await repo.UpdateUserAsync(id, user);
            return updatedUser is not null ? Results.Ok(updatedUser) : Results.NotFound();
        })
        .WithName("UpdateUser")
        .Produces<User>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // Delete User
        routes.MapDelete("/users/{id}", async (int id, IUserService repo) =>
        {
            var deletion = await repo.DeleteUserAsync(id);
            return deletion ? Results.NoContent() : Results.NotFound();
            
        })
        .WithName("DeleteUser")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}

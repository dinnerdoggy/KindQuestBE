using Microsoft.EntityFrameworkCore;
using KindQuest.Data;
using KindQuest.Interfaces;
using KindQuest.Repositories;
using KindQuest.Services;
using KindQuest.Endpoints;
using KindQuest.EndPoints;


var builder = WebApplication.CreateBuilder(args);
// Add configuration to read from user secrets when in development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var connectionString = builder.Configuration.GetConnectionString("KindQuestDbConnectionString");
builder.Services.AddDbContext<KindQuestDbContext>(options => options.UseNpgsql(connectionString));

// Here we are registering the services and repositories with the DI container.
// The DI container will inject the services and repositories into the endpoints (controllers).
// DI (Dependency Injection) is a design pattern that allows us to develop loosely coupled code.
// Loosely coupled code is code where the classes and objects are independent of each other.
// This makes the code easier to maintain, test, and extend.
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

// Here we are calling the extension method MapWeatherEndpoints() to map the weather endpoints.
// The extension method is defined in the KindQuestEndpoints class.
// The extension method is a static method that extends the IEndpointRouteBuilder interface.
// The extension method is used to group related endpoints together.
// An extension method is a special kind of static method that is used to add new functionality to existing types.
// A static method is a method that belongs to the class itself, not to instances of the class.
app.MapProjectEndpoints();
app.MapJobEndpoints();
app.MapUserEndpoints();
app.MapProjectEndpoints();
app.MapJobEndpoints();
app.MapUserEndpoints();

app.Run();

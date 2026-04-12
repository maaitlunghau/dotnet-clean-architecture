using CLEAN.APPLICATION.Interfaces;
using CLEAN.APPLICATION.Services;
using CLEAN.DOMAIN.Entities;
using CLEAN.DOMAIN.Interfaces;
using CLEAN.INFRASTRUCTURE.Persistence;
using CLEAN.INFRASTRUCTURE.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("MySQL");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString))
    );
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.UseHttpsRedirection();

app.Run();
using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;
using FurryBackend.Services;
using FurryBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<Config>();
builder.Services.AddDbContext<FurryBackendContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IMyFriendsService, MyFriendsService>();
builder.Services.AddScoped<IMyFavoritesService, MyFavoritesService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<FurryBackendContext>().Database.EnsureCreated();
}

app.Run();

using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddTransient<Config>();
builder.Services.AddDbContext<FurryBackendContext>(options =>
    options.UseNpgsql(@"Host=localhost;Username=furry;Password=furrypass;Database=furrydb"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();

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

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<FurryBackendContext>().Database.EnsureCreated();

app.Run();

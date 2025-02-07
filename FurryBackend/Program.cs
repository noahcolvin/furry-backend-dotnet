using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddTransient<Config>();
builder.Services.AddDbContext<FurryBackendContext>(options =>
    options.UseInMemoryDatabase("FurryBackend").UseSeeding((context, _) =>
        {
            var storageUrl = builder.Services.BuildServiceProvider().GetService<Config>()?.StorageUrl ?? throw new ArgumentNullException("StorageUrl");
            var hasFriends = context.Set<MyFriend>().Any();
            if (!hasFriends)
            {
                context.Set<MyFriend>().AddRange(
                   Seed.MyFriendsData(storageUrl)
                );
                context.SaveChanges();
            }

            var hasItems = context.Set<StoreItem>().Any();
            if (!hasItems)
            {
                context.Set<StoreItem>().AddRange(
                    Seed.StoreItems(storageUrl)
                );
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var storageUrl = builder.Services.BuildServiceProvider().GetService<Config>()?.StorageUrl ?? throw new ArgumentNullException("StorageUrl");
            var hasFriends = context.Set<MyFriend>().Any();
            if (hasFriends)
            {
                context.Set<MyFriend>().AddRange(
                    Seed.MyFriendsData(storageUrl)
                );
                await context.SaveChangesAsync(cancellationToken);
            }

            var hasItems = context.Set<StoreItem>().Any();
            if (!hasItems)
            {
                context.Set<StoreItem>().AddRange(
                    Seed.StoreItems(storageUrl)
                );
                await context.SaveChangesAsync(cancellationToken);
            }
        }));
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

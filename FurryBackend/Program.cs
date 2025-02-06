using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<FurryBackendContext>(options =>
    options.UseInMemoryDatabase("FurryBackend").UseSeeding((context, _) =>
        {
            var hasFriends = context.Set<MyFriend>().Any();
            if (!hasFriends)
            {
                context.Set<MyFriend>().AddRange(
                   Seed.MyFriendsData
                );
                context.SaveChanges();
            }

            var hasItems = context.Set<StoreItem>().Any();
            if (!hasItems)
            {
                context.Set<StoreItem>().AddRange(
                    Seed.StoreItems
                );
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var hasFriends = context.Set<MyFriend>().Any();
            if (hasFriends)
            {
                context.Set<MyFriend>().AddRange(
                    Seed.MyFriendsData
                );
                await context.SaveChangesAsync(cancellationToken);
            }

            var hasItems = context.Set<StoreItem>().Any();
            if (!hasItems)
            {
                context.Set<StoreItem>().AddRange(
                    Seed.StoreItems
                );
                await context.SaveChangesAsync(cancellationToken);
            }
        }));
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

app.Run();

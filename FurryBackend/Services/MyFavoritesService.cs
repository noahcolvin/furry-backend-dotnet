using FurryBackend.Models;
using FurryBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Services;

public class MyFavoritesService(FurryBackendContext context) : IMyFavoritesService
{
    public async Task<List<StoreItem>> GetMyFavoriteItems()
    {
        //In a real-world scenario, you would want to get the user's favorite items based on their user
        var items = await context.StoreItems.ToListAsync();
        return items.OrderBy(_ => Random.Shared.Next()).Take(Random.Shared.Next(2, 5)).ToList();
    }
}

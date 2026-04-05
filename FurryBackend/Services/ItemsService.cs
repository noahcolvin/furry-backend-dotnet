using FurryBackend.Models;
using FurryBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Services;

public class ItemsService(FurryBackendContext context) : IItemsService
{
    public async Task<List<StoreItem>> GetStoreItems(string? animal = null, string? product = null, string? search = null)
    {
        var query = context.StoreItems.AsQueryable();

        if (!string.IsNullOrEmpty(animal))
            query = query.Where(item => item.Categories.Contains(animal.ToLowerInvariant()));

        if (!string.IsNullOrEmpty(product))
            query = query.Where(item => item.Categories.Contains(product.ToLowerInvariant()));

        if (!string.IsNullOrEmpty(search))
        {
            var lowerSearch = search.ToLowerInvariant();
            query = query.Where(item => item.Name.ToLower().Contains(lowerSearch) || item.Description.ToLower().Contains(lowerSearch));
        }

        return await query.ToListAsync();
    }
}

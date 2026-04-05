using FurryBackend.Models;

namespace FurryBackend.Services.Interfaces;

public interface IItemsService
{
    Task<List<StoreItem>> GetStoreItems(string? animal = null, string? product = null, string? search = null);
}

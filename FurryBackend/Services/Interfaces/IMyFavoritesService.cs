using FurryBackend.Models;

namespace FurryBackend.Services.Interfaces;

public interface IMyFavoritesService
{
    Task<List<StoreItem>> GetMyFavoriteItems();
}

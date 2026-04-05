using Microsoft.AspNetCore.Mvc;
using FurryBackend.Models;
using FurryBackend.Services.Interfaces;

namespace FurryBackend.Controllers
{
    [Route("api/my-favorite-items")]
    [ApiController]
    public class MyFavoritesController(IMyFavoritesService myFavoritesService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreItem>>> GetMyFavoriteItems()
        {
            var items = await myFavoritesService.GetMyFavoriteItems();
            return Ok(items);
        }
    }
}

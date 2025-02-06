using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;

namespace FurryBackend.Controllers
{
    [Route("api/my-favorite-items")]
    [ApiController]
    public class MyFavoritesController(FurryBackendContext context) : ControllerBase
    {
        private readonly FurryBackendContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreItem>>> GetMyFavoriteItems()
        {
            //In a real-world scenario, you would want to get the user's favorite items based on their user
            var items = await _context.StoreItems.ToListAsync();
            var random = new Random();
            var randomItems = items.OrderBy(x => random.Next()).Take(random.Next(2, 5)).ToList();
            return Ok(randomItems);
        }
    }
}

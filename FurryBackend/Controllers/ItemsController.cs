using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;

namespace FurryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController(FurryBackendContext context) : ControllerBase
    {
        private readonly FurryBackendContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreItem>>> GetStoreItems([FromQuery] string? animal = null, [FromQuery] string? product = null, [FromQuery] string? search = null)
        {
            var query = _context.StoreItems.AsQueryable();

            if (!string.IsNullOrEmpty(animal))
            {
                query = query.Where(item => item.Categories.Contains(animal));
            }

            if (!string.IsNullOrEmpty(product))
            {
                query = query.Where(item => item.Categories.Contains(product));
            }

            if (!string.IsNullOrEmpty(search))
            {
                var lowerSearch = search.ToLowerInvariant();
                query = query.Where(item => item.Name.Contains(lowerSearch, StringComparison.InvariantCultureIgnoreCase) || item.Description.Contains(lowerSearch, StringComparison.InvariantCultureIgnoreCase));
            }

            var items = await query.ToListAsync();
            return Ok(items);
        }
    }
}

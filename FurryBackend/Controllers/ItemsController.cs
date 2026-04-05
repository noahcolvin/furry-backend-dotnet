using Microsoft.AspNetCore.Mvc;
using FurryBackend.Models;
using FurryBackend.Services.Interfaces;

namespace FurryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController(IItemsService itemsService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreItem>>> GetStoreItems([FromQuery] string? animal = null, [FromQuery] string? product = null, [FromQuery] string? search = null)
        {
            var items = await itemsService.GetStoreItems(animal, product, search);
            return Ok(items);
        }
    }
}

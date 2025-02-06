using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FurryBackend.Models;

namespace FurryBackend.Controllers
{
    [Route("api/my-friends")]
    [ApiController]
    public class MyFriendsController(FurryBackendContext context) : ControllerBase
    {
        private readonly FurryBackendContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyFriend>>> GetMyFriends()
        {
            //In a real-world scenario, you would want to get the user's friends based on their user
            var friends = await _context.MyFriends.ToListAsync();
            var random = new Random();
            var randomFriends = friends.OrderBy(x => random.Next()).Take(random.Next(1, 4)).ToList();
            return Ok(randomFriends);
        }
    }
}

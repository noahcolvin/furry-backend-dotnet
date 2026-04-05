using Microsoft.AspNetCore.Mvc;
using FurryBackend.Models;
using FurryBackend.Services.Interfaces;

namespace FurryBackend.Controllers
{
    [Route("api/my-friends")]
    [ApiController]
    public class MyFriendsController(IMyFriendsService myFriendsService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyFriend>>> GetMyFriends()
        {
            var friends = await myFriendsService.GetMyFriends();
            return Ok(friends);
        }
    }
}

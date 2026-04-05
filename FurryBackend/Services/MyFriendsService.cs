using FurryBackend.Models;
using FurryBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Services;

public class MyFriendsService(FurryBackendContext context) : IMyFriendsService
{
    public async Task<List<MyFriend>> GetMyFriends()
    {
        //In a real-world scenario, you would want to get the user's friends based on their user
        var friends = await context.MyFriends.ToListAsync();
        return friends.OrderBy(_ => Random.Shared.Next()).Take(Random.Shared.Next(1, 4)).ToList();
    }
}

using FurryBackend.Models;

namespace FurryBackend.Services.Interfaces;

public interface IMyFriendsService
{
    Task<List<MyFriend>> GetMyFriends();
}

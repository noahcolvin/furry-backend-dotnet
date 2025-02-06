using Microsoft.AspNetCore.Mvc;
using FurryBackend.Controllers;
using FurryBackend.Models;
using FluentAssertions;
using FurryBackend.Tests.Fixtures;

namespace FurryBackend.Tests.Controllers
{
  public class MyFriendsControllerTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
  {
    private DatabaseFixture _fixture = fixture;
    private MyFriendsController _controller = new MyFriendsController(fixture.Db);

    [Fact]
    public async Task GetMyFriends_ReturnsRandomSubsetOfFriends()
    {
      var result = await _controller.GetMyFriends();

      var okResult = Assert.IsType<OkObjectResult>(result.Result);
      var returnValue = Assert.IsType<List<MyFriend>>(okResult.Value);
      returnValue.Count.Should().BeInRange(1, 3);
      returnValue.Should().BeSubsetOf(_fixture.MyFriends);
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using FurryBackend.Controllers;
using FurryBackend.Models;
using FluentAssertions;
using FurryBackend.Tests.Fixtures;

namespace FurryBackend.Tests.Controllers
{
  public class MyFavoritesControllerTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
  {
    private DatabaseFixture _fixture = fixture;
    private MyFavoritesController _controller = new MyFavoritesController(fixture.Db);

    [Fact]
    public async Task GetMyFavoriteItems_ReturnsRandomSubsetOfStoreItems()
    {
      var result = await _controller.GetMyFavoriteItems();

      var okResult = Assert.IsType<OkObjectResult>(result.Result);
      var returnValue = Assert.IsType<List<StoreItem>>(okResult.Value);
      returnValue.Count.Should().BeInRange(2, 4);
      returnValue.Should().BeSubsetOf(_fixture.StoreItems);
    }
  }
}
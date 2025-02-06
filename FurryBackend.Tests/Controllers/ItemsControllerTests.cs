using FluentAssertions;
using FurryBackend.Controllers;
using FurryBackend.Models;
using FurryBackend.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc;

namespace FurryBackend.Tests.Controllers;

public class ItemsControllerTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
  private DatabaseFixture _fixture = fixture;
  private ItemsController _controller = new ItemsController(fixture.Db);

  [Fact]
  public async Task GetStoreItems_ReturnsAllItems()
  {
    var result = await _controller.GetStoreItems();

    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnValue = Assert.IsType<List<StoreItem>>(okResult.Value);
    returnValue.Should().BeEquivalentTo(_fixture.StoreItems);
  }
}
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

  [Fact]
  public async Task GetStoreItems_FiltersOnAnimal()
  {
    var result = await _controller.GetStoreItems(animal: "Dog");

    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnValue = Assert.IsType<List<StoreItem>>(okResult.Value);
    returnValue.Count.Should().Be(2);
    returnValue.ForEach(i => i.Categories.Should().Contain("dog"));
  }

  [Fact]
  public async Task GetStoreItems_FiltersOnProduct()
  {
    var result = await _controller.GetStoreItems(product: "Food");

    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnValue = Assert.IsType<List<StoreItem>>(okResult.Value);
    returnValue.Count.Should().Be(1);
    returnValue.ForEach(i => i.Categories.Should().Contain("food"));
  }

  [Fact]
  public async Task GetStoreItems_Searches()
  {
    var result = await _controller.GetStoreItems(search: "HerE");

    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnValue = Assert.IsType<List<StoreItem>>(okResult.Value);
    returnValue.Count.Should().Be(2);
    returnValue.ForEach(i => (i.Name.Contains("Here", StringComparison.InvariantCultureIgnoreCase) || i.Description.Contains("Here", StringComparison.InvariantCultureIgnoreCase)).Should().BeTrue());
  }

  [Fact]
  public async Task GetStoreItems_FiltersAllTheThings()
  {
    var result = await _controller.GetStoreItems(animal: "Dog", product: "Food", search: "HeRe");

    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnValue = Assert.IsType<List<StoreItem>>(okResult.Value);
    returnValue.Count.Should().Be(1);
    returnValue.Should().AllSatisfy(i =>
    {
      i.Categories.Should().Contain("dog");
      i.Categories.Should().Contain("food");
      (i.Name.Contains("Here", StringComparison.InvariantCultureIgnoreCase) || i.Description.Contains("Here", StringComparison.InvariantCultureIgnoreCase)).Should().BeTrue();
    });

    returnValue.ForEach(i => (i.Name.Contains("Here", StringComparison.InvariantCultureIgnoreCase) || i.Description.Contains("Here", StringComparison.InvariantCultureIgnoreCase)).Should().BeTrue());
  }
}
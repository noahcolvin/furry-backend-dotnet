using FurryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Tests.Fixtures;

public class DatabaseFixture : IDisposable
{
  public List<StoreItem> StoreItems { get; private set; } = [
    new() { Id = "1", Name = "Item1", Description = "Description1", Price = 1.99m, Image = "https://example.com/image1.jpg", Categories = ["Category1", "Category2"], About = ["About1", "About2"], Rating = 4.5},
    new() { Id = "2", Name = "Item2", Description = "Description2", Price = 2.99m, Image = "https://example.com/image2.jpg", Categories = ["Category2", "Category3"], About = ["About1", "About2"], Rating = 3.5},
    new() { Id = "3", Name = "Item3", Description = "Description3", Price = 3.99m, Image = "https://example.com/image3.jpg", Categories = ["Category3", "Category4"], About = ["About1", "About2"], Rating = 3.5},
    new() { Id = "4", Name = "Item4", Description = "Description4", Price = 4.99m, Image = "https://example.com/image4.jpg", Categories = ["Category4", "Category5"], About = ["About1", "About2"], Rating = 4}
  ];
  public List<MyFriend> MyFriends { get; private set; } = [
    new() { Id = 1, Name = "Friend1", Image = "https://example.com/image1.jpg"},
    new() { Id = 2, Name = "Friend2", Image = "https://example.com/image2.jpg"},
    new() { Id = 3, Name = "Friend3", Image = "https://example.com/image.3jpg"},
    new() { Id = 4, Name = "Friend4", Image = "https://example.com/image.j4pg"}
  ];

  public FurryBackendContext Db { get; private set; }

  public DatabaseFixture()
  {
    var options = new DbContextOptionsBuilder<FurryBackendContext>()
      .UseInMemoryDatabase(Guid.NewGuid().ToString()) //Make sure to use a unique name for the database
      .UseSeeding((context, _) =>
        {
          if (!context.StoreItems.Any())
          {
            context.StoreItems.AddRange(
             StoreItems
            );
            context.SaveChanges();
          }

          if (!context.MyFriends.Any())
          {
            context.MyFriends.AddRange(
             MyFriends
            );
            context.SaveChanges();
          }
        }).Options;
    Db = new FurryBackendContext(options);
  }

  public void Dispose()
  {
    Db.Dispose();
  }
}
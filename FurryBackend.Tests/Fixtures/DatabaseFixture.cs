using FurryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Tests.Fixtures;

public class DatabaseFixture : IDisposable
{
    public List<StoreItem> StoreItems { get; private set; } = new List<StoreItem>
    {
        new() { Id = "1", Name = "Item1", Description = "Description1", Price = 1.99m, Image = "https://example.com/image1.jpg", Categories = new List<string> { "category1", "category2", "dog" }, About = new List<string> { "About1", "About2" }, Rating = 4.5 },
        new() { Id = "2", Name = "Item2", Description = "Description2 here", Price = 2.99m, Image = "https://example.com/image2.jpg", Categories = new List<string> { "category2", "category3", "food", "dog" }, About = new List<string> { "About1", "About2" }, Rating = 3.5 },
        new() { Id = "3", Name = "Item3", Description = "Description3", Price = 3.99m, Image = "https://example.com/image3.jpg", Categories = new List<string> { "category3", "category4" }, About = new List<string> { "About1", "About2" }, Rating = 3.5 },
        new() { Id = "4", Name = "Item4 here", Description = "Description4", Price = 4.99m, Image = "https://example.com/image4.jpg", Categories = new List<string> { "category4", "category5" }, About = new List<string> { "About1", "About2" }, Rating = 4 }
    };

    public List<MyFriend> MyFriends { get; private set; } = new List<MyFriend>
    {
        new() { Id = 1, Name = "Friend1", Image = "https://example.com/image1.jpg" },
        new() { Id = 2, Name = "Friend2", Image = "https://example.com/image2.jpg" },
        new() { Id = 3, Name = "Friend3", Image = "https://example.com/image3.jpg" },
        new() { Id = 4, Name = "Friend4", Image = "https://example.com/image4.jpg" }
    };

    public FurryBackendContext Db { get; private set; }

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<FurryBackendContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Make sure to use a unique name for the database
            .Options;
        Db = new TestFurryBackendContext(options, null, MyFriends, StoreItems);
        Db.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Db.Dispose();
    }
}

public class TestFurryBackendContext : FurryBackendContext
{
    private readonly List<MyFriend> _myFriends;
    private readonly List<StoreItem> _storeItems;

    public TestFurryBackendContext(DbContextOptions<FurryBackendContext> options, Config? _, List<MyFriend> myFriends, List<StoreItem> storeItems) : base(options, _)
    {
        _myFriends = myFriends;
        _storeItems = storeItems;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyFriend>().HasData(_myFriends);
        modelBuilder.Entity<StoreItem>().HasData(_storeItems);
    }
}
using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Models;

public class FurryBackendContext : DbContext
{
    protected readonly Config _config;

    public FurryBackendContext(DbContextOptions<FurryBackendContext> options, Config config)
        : base(options)
    {
        _config = config;
    }

    public virtual DbSet<MyFriend> MyFriends { get; set; }
    public virtual DbSet<StoreItem> StoreItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        modelBuilder.Entity<MyFriend>().HasData(Seed.MyFriendsData(_config.StorageUrl));
        modelBuilder.Entity<StoreItem>().HasData(Seed.StoreItems(_config.StorageUrl));
    }
}
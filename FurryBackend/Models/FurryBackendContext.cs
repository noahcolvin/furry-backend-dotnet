using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Models;

public class FurryBackendContext : DbContext
{
    public FurryBackendContext() { }

    public FurryBackendContext(DbContextOptions<FurryBackendContext> options)
        : base(options)
    {
        //Not the best place for this, but it will do for now
        Database.EnsureCreated();
    }

    public virtual DbSet<MyFriend> MyFriends { get; set; }
    public virtual DbSet<StoreItem> StoreItems { get; set; }
}
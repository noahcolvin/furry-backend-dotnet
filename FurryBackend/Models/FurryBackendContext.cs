using Microsoft.EntityFrameworkCore;

namespace FurryBackend.Models;

public class FurryBackendContext : DbContext
{
    public FurryBackendContext(DbContextOptions<FurryBackendContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MyFriend> MyFriends { get; set; }
    public virtual DbSet<StoreItem> StoreItems { get; set; }
}
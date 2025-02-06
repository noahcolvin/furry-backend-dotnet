namespace FurryBackend.Models;

public class StoreItem
{
  public required string Id { get; set; }
  public required string Name { get; set; }
  public decimal Price { get; set; }
  public required string Description { get; set; }
  public double Rating { get; set; }
  public required string Image { get; set; }
  public required List<string> About { get; set; }
  public List<string> Categories { get; set; } = [];
}

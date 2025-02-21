namespace FurryBackend.Models;

public class StoreItem
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }
    public double Rating { get; set; }
    public required string Image { get; set; }
    public required List<string> About { get; set; }
    public List<string> Categories { get; set; } = [];

    public override bool Equals(object obj)
    {
        if (obj is StoreItem other)
        {
            return Id == other.Id &&
                   Name == other.Name &&
                   Price == other.Price &&
                   Description == other.Description &&
                   Rating == other.Rating &&
                   Image == other.Image &&
                   About.SequenceEqual(other.About) &&
                   Categories.SequenceEqual(other.Categories);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price, Description, Rating, Image,
                                string.Join(",", About), string.Join(",", Categories));
    }
}

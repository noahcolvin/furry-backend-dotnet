namespace FurryBackend.Models;

public class MyFriend
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is MyFriend other)
        {
            return Id == other.Id && Name == other.Name && Image == other.Image;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Image);
    }
}

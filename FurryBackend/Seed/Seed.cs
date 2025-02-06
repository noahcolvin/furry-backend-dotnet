using FurryBackend.Models;

public static class Seed
{
  private static readonly string storageUrl = "https://example.com";

  public static List<MyFriend> MyFriendsData => [
      new MyFriend { Name = "Alice", Image = storageUrl + "/furry-public/pets/pet1.jpg" },
      new MyFriend { Name = "Bob", Image = storageUrl + "/furry-public/pets/pet2.jpg" },
      new MyFriend { Name = "Charlie", Image = storageUrl + "/furry-public/pets/pet3.jpg" },
      new MyFriend { Name = "David", Image = storageUrl + "/furry-public/pets/pet4.jpg" },
      new MyFriend { Name = "Eve", Image = storageUrl + "/furry-public/pets/pet5.jpg" },
      new MyFriend { Name = "Frank", Image = storageUrl + "/furry-public/pets/pet6.jpg" },
      new MyFriend { Name = "Grace", Image = storageUrl + "/furry-public/pets/pet7.jpg" },
      new MyFriend { Name = "Hank", Image = storageUrl + "/furry-public/pets/pet8.jpg" }
    ];

  public static List<StoreItem> StoreItems => [
    new StoreItem
    {
        Id = "1",
        Name = "Flutter Bird Food",
        Price = 59.99m,
        Description = "All natural bird food made with the finest seeds and nuts.",
        Rating = 4.5,
        Image = storageUrl + "/furry-public/store-items/bird_food.jpg",
        About = ["Safe for all bird types", "No artificial flavors", "No preservatives"],
        Categories = ["bird", "food"]
    },
    new StoreItem
    {
        Id = "2",
        Name = "Meow Master Cat Food",
        Price = 19.99m,
        Description = "All natural cat food made with exclusive fish and vegetables.",
        Rating = 3.2,
        Image = storageUrl + "/furry-public/store-items/cat_food_can.jpg",
        About = ["Made in the UK", "No mice bits", "Mother approved"],
        Categories = ["cat", "food"]
    },
    new StoreItem
    {
        Id = "3",
        Name = "Cities Cat Tower",
        Price = 74.99m,
        Description = "A cat tower that is perfect for any cat to play and sleep on.",
        Rating = 5.0,
        Image = storageUrl + "/furry-public/store-items/cat_tower.jpg",
        About = ["Real carpet", "No assembly required", "Made in China"],
        Categories = ["cat", "toy"]
    },
    new StoreItem
    {
        Id = "4",
        Name = "Mr Mouse Cat Toy",
        Price = 9.99m,
        Description = "Realistic mouse toy that will keep your cat entertained for hours.",
        Rating = 2.7,
        Image = storageUrl + "/furry-public/store-items/cat_toy.jpg",
        About = ["Catnip sold separately", "No real mice", "No batteries required"],
        Categories = ["cat", "toy"]
    },
    new StoreItem
    {
        Id = "5",
        Name = "Bluz Dog Toy",
        Price = 14.99m,
        Description = "A chew toy that is perfect for any dog to play and chew on.",
        Rating = 4.5,
        Image = storageUrl + "/furry-public/store-items/dog_chew_toy.jpg",
        About = ["Made for all dog sizes", "For tough chewers", "Made in China"],
        Categories = ["dog", "toy"]
    },
    new StoreItem
    {
        Id = "6",
        Name = "Sam's Natural Dog Food",
        Price = 24.99m,
        Description = "Made with real chicken and vegetables, this dog food is perfect for any dog.",
        Rating = 4.2,
        Image = storageUrl + "/furry-public/store-items/dog_food_can.jpg",
        About = ["Made in the USA", "No artificial flavors", "No preservatives"],
        Categories = ["dog", "food"]
    },
    new StoreItem
    {
        Id = "7",
        Name = "Good Boy Dog Food",
        Price = 59.99m,
        Description = "All-natural dog food made with the finest chicken and vegetables.",
        Rating = 4.5,
        Image = storageUrl + "/furry-public/store-items/dog_food.jpg",
        About = ["Made in the USA", "No artificial flavors", "No preservatives"],
        Categories = ["dog", "food"]
    },
    new StoreItem
    {
        Id = "8",
        Name = "Right Stufz Dog Toy",
        Price = 13.99m,
        Description = "Stuffed toy that is perfect for any dog to play and chew.",
        Rating = 4.0,
        Image = storageUrl + "/furry-public/store-items/dog_stuffed_toy.jpg",
        About = ["Made for all dog sizes", "Squeaker", "Made in Mexico"],
        Categories = ["dog", "toy"]
    },
    new StoreItem
    {
        Id = "9",
        Name = "Deep Sea Fish Tank",
        Price = 129.99m,
        Description = "50-gallon fish tank that is perfect for any fish to swim in.",
        Rating = 3.5,
        Image = storageUrl + "/furry-public/store-items/fish_tank.jpg",
        About = ["Made in Canada", "No fish included", "No water included"],
        Categories = ["fish", "toy"]
    },
    new StoreItem
    {
        Id = "10",
        Name = "Ballz Hamster Toy",
        Price = 19.99m,
        Description = "A ball that is perfect for any hamster to play and run in.",
        Rating = 2.5,
        Image = storageUrl + "/furry-public/store-items/hamster_ball.jpg",
        About = ["Made for all hamster sizes", "No real hamsters", "Do not use in water"],
        Categories = ["hamster", "toy"]
    },
    new StoreItem
    {
        Id = "11",
        Name = "Munchie Hamster Food",
        Price = 19.99m,
        Description = "All natural hamster food made with the finest seeds and nuts.",
        Rating = 4.1,
        Image = storageUrl + "/furry-public/store-items/hamster_food.jpg",
        About = ["Safe for all hamster types", "No artificial flavors", "No preservatives"],
        Categories = ["hamster", "food"]
    }
  ];
}
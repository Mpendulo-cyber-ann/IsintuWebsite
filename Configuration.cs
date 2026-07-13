using System.Data.Entity.Migrations;
using IsintuWebsite.Models;

namespace IsintuWebsite.Migrations
{
    // Run "Enable-Migrations" then "Update-Database" in the Package Manager
    // Console after the connection string is set up, and this seed data will
    // load automatically.
    internal sealed class Configuration : DbMigrationsConfiguration<IsintuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IsintuDbContext context)
        {
            context.ClothingItems.AddOrUpdate(a => a.Name,
                new ClothingItem
                {
                    Name = "Zulu Traditional Attire - Full Set",
                    Category = "Men",
                    Size = "Medium",
                    Color = "Red/Black/White",
                    Material = "Cotton & Beadwork",
                    Description = "A full Zulu regalia set including the isidwaba wrap, ibheshu, and beaded chest piece.",
                    BuyPrice = 5400.00m,
                    RentPricePerDay = 340.00m,
                    AvailabilityStatus = "Available",
                    ImageUrl = "/Images/zulu-attire-main.jpg"
                },
                new ClothingItem
                {
                    Name = "Zulu Isicholo Headgear",
                    Category = "Accessories",
                    Size = "One Size",
                    Color = "Red",
                    Material = "Woven Grass & Fabric",
                    Description = "Traditional Zulu married woman's hat, hand-woven and finished in red fabric.",
                    BuyPrice = 5400.00m,
                    RentPricePerDay = 340.00m,
                    AvailabilityStatus = "Available",
                    ImageUrl = "/Images/zulu-isicholo.jpg"
                },
                new ClothingItem
                {
                    Name = "Zulu Beaded Necklace Set",
                    Category = "Accessories",
                    Size = "One Size",
                    Color = "Multicolour",
                    Material = "Glass Beads",
                    Description = "A layered beaded necklace set, handmade in traditional Zulu patterns and colours.",
                    BuyPrice = 5400.00m,
                    RentPricePerDay = 340.00m,
                    AvailabilityStatus = "Available",
                    ImageUrl = "/Images/zulu-beaded-necklace.jpg"
                },
                new ClothingItem
                {
                    Name = "Zulu Traditional Dress - Women's",
                    Category = "Women",
                    Size = "Medium",
                    Color = "Red/Black",
                    Material = "Cotton & Beadwork",
                    Description = "A traditional Zulu women's dress with matching beaded belt and shoulder accessories.",
                    BuyPrice = 5400.00m,
                    RentPricePerDay = 340.00m,
                    AvailabilityStatus = "Available",
                    ImageUrl = "/Images/zulu-womens-dress.jpg"
                },
                new ClothingItem
                {
                    Name = "Zulu Shield & Spear Prop Set",
                    Category = "Accessories",
                    Size = "One Size",
                    Color = "Brown/White",
                    Material = "Cowhide & Wood",
                    Description = "A decorative Zulu shield and spear set, commonly paired with the full men's attire.",
                    BuyPrice = 5400.00m,
                    RentPricePerDay = 340.00m,
                    AvailabilityStatus = "Available",
                    ImageUrl = "/Images/zulu-shield-spear.jpg"
                }
            );
        }
    }
}

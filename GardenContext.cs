using Microsoft.EntityFrameworkCore;

namespace Models;

public class GardenContext(DbContextOptions<GardenContext> options) : DbContext(options)
{
    public DbSet<Crop> Crops { get; set; }
    public DbSet<PlannedCrop> PlannedCrops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crop>().HasData(
            new Crop { Name = "Arugula", GrowthTime = 30, Yield = 2, Type = CropType.Vegetable },
            new Crop { Name = "Basil", GrowthTime = 30, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Beetroot", GrowthTime = 50, Yield = 3, Type = CropType.RootVegetable },
            new Crop { Name = "Bell Pepper", GrowthTime = 70, Yield = 6, Type = CropType.Vegetable },
            new Crop { Name = "Carrot", GrowthTime = 50, Yield = 3, Type = CropType.RootVegetable },
            new Crop { Name = "Chili Pepper", GrowthTime = 75, Yield = 4, Type = CropType.Vegetable },
            new Crop { Name = "Chinese Cabbage", GrowthTime = 60, Yield = 3, Type = CropType.Vegetable },
            new Crop { Name = "Chives", GrowthTime = 40, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Cilantro", GrowthTime = 30, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Cucumber", GrowthTime = 60, Yield = 4, Type = CropType.Melon },
            new Crop { Name = "Eggplant", GrowthTime = 80, Yield = 4, Type = CropType.Vegetable },
            new Crop { Name = "Garlic Greens", GrowthTime = 30, Yield = 3, Type = CropType.Vegetable },
            new Crop { Name = "Green Onion", GrowthTime = 20, Yield = 3, Type = CropType.Vegetable },
            new Crop { Name = "Kale", GrowthTime = 45, Yield = 2, Type = CropType.Vegetable },
            new Crop { Name = "Lettuce", GrowthTime = 40, Yield = 2, Type = CropType.Vegetable },
            new Crop { Name = "Mint", GrowthTime = 25, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Oregano", GrowthTime = 35, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Pak Choi (Bok Choy)", GrowthTime = 45, Yield = 3, Type = CropType.Vegetable },
            new Crop { Name = "Parsley", GrowthTime = 40, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Radish", GrowthTime = 25, Yield = 3, Type = CropType.RootVegetable },
            new Crop { Name = "Rosemary", GrowthTime = 60, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Spinach", GrowthTime = 30, Yield = 2, Type = CropType.Vegetable },
            new Crop { Name = "Swiss Chard", GrowthTime = 50, Yield = 3, Type = CropType.Vegetable },
            new Crop { Name = "Thyme", GrowthTime = 40, Yield = 0, Type = CropType.Herb },
            new Crop { Name = "Tomato", GrowthTime = 60, Yield = 6, Type = CropType.Fruit },
            new Crop { Name = "Turnip", GrowthTime = 40, Yield = 3, Type = CropType.Tuber }
        );
    }
}
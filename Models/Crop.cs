using Microsoft.EntityFrameworkCore;

namespace Models;

public class Crop
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int GrowthTime { get; set; }
    public int Yield { get; set; }
}

public class CropDBContext : DbContext
{
    public DbSet<Crop> Crops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crop>().HasKey(c => c.Id);
        modelBuilder.Entity<Crop>().Property(c => c.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Crop>().HasData(
            // Leafy Greens
            new Crop { Name = "Arugula", GrowthTime = 30, Yield = 2 },
            new Crop { Name = "Chinese Cabbage", GrowthTime = 60, Yield = 3 },
            new Crop { Name = "Kale", GrowthTime = 45, Yield = 2 },
            new Crop { Name = "Lettuce", GrowthTime = 40, Yield = 2 },
            new Crop { Name = "Pak Choi (Bok Choy)", GrowthTime = 45, Yield = 3 },
            new Crop { Name = "Spinach", GrowthTime = 30, Yield = 2 },
            new Crop { Name = "Swiss Chard", GrowthTime = 50, Yield = 3 },

            // Fruiting Veggies
            new Crop { Name = "Bell Pepper", GrowthTime = 70, Yield = 6 },
            new Crop { Name = "Chili Pepper", GrowthTime = 75, Yield = 4 },
            new Crop { Name = "Cucumber", GrowthTime = 60, Yield = 4 },
            new Crop { Name = "Eggplant", GrowthTime = 80, Yield = 4 },
            new Crop { Name = "Tomato", GrowthTime = 60, Yield = 6 },

            // Root Veggies
            new Crop { Name = "Beetroot", GrowthTime = 50, Yield = 3 },
            new Crop { Name = "Carrot", GrowthTime = 50, Yield = 3 },
            new Crop { Name = "Radish", GrowthTime = 25, Yield = 3 },
            new Crop { Name = "Turnip", GrowthTime = 40, Yield = 3 },

            // Alliums
            new Crop { Name = "Garlic Greens", GrowthTime = 30, Yield = 3 },
            new Crop { Name = "Green Onion", GrowthTime = 20, Yield = 3 },

            // Herbs (Yield set to 0)
            new Crop { Name = "Basil", GrowthTime = 30, Yield = 0 },
            new Crop { Name = "Chives", GrowthTime = 40, Yield = 0 },
            new Crop { Name = "Cilantro", GrowthTime = 30, Yield = 0 },
            new Crop { Name = "Mint", GrowthTime = 25, Yield = 0 },
            new Crop { Name = "Oregano", GrowthTime = 35, Yield = 0 },
            new Crop { Name = "Parsley", GrowthTime = 40, Yield = 0 },
            new Crop { Name = "Rosemary", GrowthTime = 60, Yield = 0 },
            new Crop { Name = "Thyme", GrowthTime = 40, Yield = 0 }
        );
    }
}


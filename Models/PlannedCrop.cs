using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
namespace Models;

public class PlannedCrop
{
    public Guid Id { get; set; }
    public Crop Crop { get; set; }
    public DateTime PlantingDate { get; set; }
    public int Quantity { get; set; }

    [DisplayName("Expected Harvest Date")]
    public DateTime ExpectedHarvestDate => PlantingDate.AddDays(Crop.GrowthTime);

    [DisplayName("Expected Yield")]
    public int ExpectedYield => Crop.Yield * Quantity;
}

public class PlannedCropDBContext : DbContext
{
    public DbSet<PlannedCrop> PlannedCrops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlannedCrop>().HasKey(pc => pc.Id);
        modelBuilder.Entity<PlannedCrop>().Property(pc => pc.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<PlannedCrop>().HasOne(pc => pc.Crop).WithMany();
    }
}
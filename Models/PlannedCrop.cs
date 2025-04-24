using System.ComponentModel;
namespace Models;

public class PlannedCrop
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Crop Crop { get; set; }
    public DateTime PlantingDate { get; set; }
    public int Quantity { get; set; }

    [DisplayName("Expected Harvest Date")]
    public DateTime ExpectedHarvestDate => PlantingDate.AddDays(Crop.GrowthTime);

    [DisplayName("Expected Yield")]
    public int ExpectedYield => Crop.Yield * Quantity;
}
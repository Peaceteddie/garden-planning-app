namespace Models;

public class Crop
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public required string Name { get; set; }
    public CropType Type { get; set; }
    public int GrowthTime { get; set; }
    public int Yield { get; set; }
}
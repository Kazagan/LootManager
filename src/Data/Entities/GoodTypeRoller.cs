namespace Data.Entities;

public class GoodTypeRoller
{
    public int Id { get; set; }
    public int TreasureLevel { get; set; }
    public int RollMin { get; set; }
    public GoodType GoodType { get; set; }
}
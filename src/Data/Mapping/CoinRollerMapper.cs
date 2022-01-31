using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Mapping;

public static class CoinRollerMapper
{
    public static void MapCoinTable(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoinRoller>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity
                .Property(e => e.TreasureLevel)
                .IsRequired();

            entity
                .Property(e => e.RollMin)
                .IsRequired();

            entity
                .HasOne(e => e.Coin);

            entity
                .Property(e => e.DiceCount)
                .IsRequired();

            entity
                .Property(e => e.DiceSides)
                .IsRequired();

            entity
                .Property(e => e.Multiplier)
                .IsRequired();
        });
    }
}
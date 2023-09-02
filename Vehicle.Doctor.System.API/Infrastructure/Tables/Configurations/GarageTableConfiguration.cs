using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Configurations;

public static class GarageTableConfiguration
{
    public static ModelBuilder AddGarageTableRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GarageTable>()
            .HasOne(i => i.User)
            .WithMany(i => i.Garages)
            .HasForeignKey(i => i.UserId);

        modelBuilder.Entity<GarageTable>()
            .HasMany<GarageContactTable>()
            .WithOne(i => i.Garage)
            .HasForeignKey(i => i.GarageId);
        modelBuilder.Entity<GarageTable>()
            .HasMany<GarageSocialLinkTable>()
            .WithOne(i => i.Garage)
            .HasForeignKey(i => i.GarageId);

        modelBuilder.Entity<GarageContactTable>()
            .HasOne(i => i.Garage)
            .WithMany(i => i.GarageContacts)
            .HasForeignKey(i => i.GarageId);

        modelBuilder.Entity<GarageSocialLinkTable>()
            .HasOne(i => i.Garage)
            .WithMany(i => i.GarageSocialLinks)
            .HasForeignKey(i => i.GarageId);
        return modelBuilder;
    }
}
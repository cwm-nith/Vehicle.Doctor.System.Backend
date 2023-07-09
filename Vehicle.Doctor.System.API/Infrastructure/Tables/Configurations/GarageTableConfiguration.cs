using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Configurations;

public static class GarageTableConfiguration
{
    public static ModelBuilder AddGarageTableRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GarageTable>()
            .HasOne<UserTable>()
            .WithMany(i => i.Garages)
            .HasForeignKey(i=> i.UserId);

        modelBuilder.Entity<GarageTable>()
            .HasMany<GarageContactTable>()
            .WithOne(i => i.Garage)
            .HasForeignKey(i => i.GarageId);

        modelBuilder.Entity<GarageContactTable>()
            .HasOne<GarageTable>()
            .WithMany(i => i.GarageContacts)
            .HasForeignKey(i => i.GarageId);

        modelBuilder.Entity<GarageContactTable>()
            .HasMany<GarageSocialLinkTable>()
            .WithOne(i => i.GarageContact)
            .HasForeignKey(i => i.GarageContactId);

        modelBuilder.Entity<GarageSocialLinkTable>()
            .HasOne(i => i.GarageContact)
            .WithMany(i => i.GarageSocialLinks)
            .HasForeignKey(i => i.GarageContactId);
        return modelBuilder;
    }
}
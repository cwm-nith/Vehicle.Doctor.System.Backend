using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Configurations;

public static class UserTableConfiguration
{
    public static ModelBuilder AddUserTableRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTable>()
            .HasMany<GarageTable>()
            .WithOne(i => i.User)
            .HasForeignKey(i=> i.UserId);
        return modelBuilder;
    }
}
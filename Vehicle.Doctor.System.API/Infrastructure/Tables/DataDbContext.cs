using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Infrastructure.Options;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Configurations;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    public DbSet<UserTable>? Users { get; set; }
    public DbSet<GarageTable>? Garages { get; set; }
    public DbSet<GarageContactTable>? GarageContacts { get; set; }
    public DbSet<GarageSocialLinkTable>? GarageSocialLinks { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTime>()
            .HaveConversion(typeof(UtcValueConverter));
        configurationBuilder
            .Properties<DateTime?>()
            .HaveConversion(typeof(UtcValueConverterOptional));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .AddUserTableRelationship()
            .AddGarageTableRelationship();

        // ref: https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk is { IsOwnership: false, DeleteBehavior: DeleteBehavior.Cascade });
        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.NoAction;
        }

        // Global filters
        modelBuilder.ApplyGlobalFilters<ISoftDeleteTable>(e => e.DeletedAt == null);
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        BeforeSaveChanges();
        return base.SaveChanges(true);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        BeforeSaveChanges();
        return base.SaveChangesAsync(true, cancellationToken);
    }

    private void BeforeSaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(x => x.State is EntityState.Added or EntityState.Modified or EntityState.Deleted &&
                        x.Entity is IAuditableTable or ISoftDeleteTable)
            .ToArray();

        if (!modifiedEntries.Any())
        {
            return;
        }

        var userId = this.GetService<IAuthRepository>().GetUserId();

        foreach (var modifiedEntry in modifiedEntries)
        {
            switch (modifiedEntry.Entity)
            {
                case IAuditableTable auditableTable when modifiedEntry.State != EntityState.Deleted:
                    if (modifiedEntry.State == EntityState.Added)
                    {
                        auditableTable.CreatedAt = DateTime.UtcNow;
                    }

                    auditableTable.UpdatedBy = userId;
                    auditableTable.UpdatedAt = DateTime.UtcNow;
                    break;
                case ISoftDeleteTable softDeleteTable when modifiedEntry.State == EntityState.Deleted:
                    modifiedEntry.State = EntityState.Modified;
                    softDeleteTable.DeletedAt = DateTime.UtcNow;
                    softDeleteTable.DeletedBy = userId;
                    break;
            }
        }
    }
}
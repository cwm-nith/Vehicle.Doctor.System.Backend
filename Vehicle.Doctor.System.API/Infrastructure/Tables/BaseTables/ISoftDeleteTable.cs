namespace Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

public interface ISoftDeleteTable
{
    DateTime? DeletedAt { get; set; }

    long? DeletedBy { get; set; }
}
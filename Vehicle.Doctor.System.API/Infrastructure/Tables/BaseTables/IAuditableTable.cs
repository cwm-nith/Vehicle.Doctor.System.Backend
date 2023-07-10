namespace Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

public interface IAuditableTable
{
    DateTime CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }
    
    long? UpdatedBy { get; set; }
}
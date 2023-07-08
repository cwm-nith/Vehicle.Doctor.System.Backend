using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

public class BaseTable
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
}
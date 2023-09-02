using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

[Table("garage_contacts")]
public class GarageContactTable : BaseTable
{
    [Column("garage_id")]
    public long GarageId { get; set; }

    [Column("phone_number")] 
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("telegram")] 
    public string? Telegram { get; set; }

    [Column("whats_app")] 
    public string? WhatsApp { get; set; }

    [Column("we_chat")]
    public string? WeChat { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public GarageTable? Garage { get; set; }
}


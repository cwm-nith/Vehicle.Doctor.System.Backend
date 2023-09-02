using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.Shared.Enums.Garages;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

[Table("garage_social_links")]
public class GarageSocialLinkTable : BaseTable
{
    [Column("garage_id")]
    public long GarageId { get; set; }

    [Column("social_ink")]
    public string SocialLink { get; set; } = string.Empty;

    [Column("social_link_type")]
    public GarageEnums.SocialLinkType SocialLinkType { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public GarageTable? Garage { get; set; }
}
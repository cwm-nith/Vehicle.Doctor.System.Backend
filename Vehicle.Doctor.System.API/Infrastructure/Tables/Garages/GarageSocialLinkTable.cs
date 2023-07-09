using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

[Table("garage_social_links")]
public class GarageSocialLinkTable : BaseTable
{
    [Column("garage_contact_id")]
    public long GarageContactId { get; set; }

    [Column("social_ink")]
    public string SocialLink { get; set; } = string.Empty;

    [Column("social_link_type")]
    public SocialLinkType SocialLinkType { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public GarageContactTable? GarageContact { get; set; }
}

public enum SocialLinkType
{
    None = 0,
    YouTube = 1,
    Facebook = 2,
    Instagram = 3,
    Twitter = 4,
    Tamneak = 5,
    Threads = 6,
    TikTok = 7,
}
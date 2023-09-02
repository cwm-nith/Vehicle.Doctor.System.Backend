using Vehicle.Doctor.System.API.Applications.Entities.Garages;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

public static class GarageTableExtensions
{
    public static GarageDto ToDto(this GarageEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            Name = t.Name,
            Lat = t.Lat,
            GarageContacts = t.GarageContacts?.Select(i => i.ToDto()).ToList(),
            GarageSocialLinks = t.GarageSocialLinks?.Select(i => i.ToDto()).ToList(),
            UserId = t.UserId,
            Long = t.Long,
            Description = t.Description,
            Address = t.Address,
        };

    public static GarageEntity ToEntity(this GarageTable t) =>
        new()
        {

            Id = t.Id,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Name = t.Name,
            Lat = t.Lat,
            GarageContacts = t.GarageContacts?.Select(i => i.ToEntity()).ToList(),
            GarageSocialLinks = t.GarageSocialLinks?.Select(i => i.ToEntity()).ToList(),
            UserId = t.UserId,
            Long = t.Long,
            Description = t.Description,
            Address = t.Address,
        };

    public static GarageEntity ToEntity(this GarageDto t) =>
        new()
        {

            Id = t.Id,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Name = t.Name,
            Lat = t.Lat,
            GarageContacts = t.GarageContacts?.Select(i => i.ToEntity()).ToList(),
            GarageSocialLinks = t.GarageSocialLinks?.Select(i => i.ToEntity()).ToList(),
            UserId = t.UserId,
            Long = t.Long,
            Description = t.Description,
            Address = t.Address,
        };

    public static GarageTable ToTable(this GarageEntity t) =>
        new()
        {
            Id = t.Id,
            Name = t.Name,
            Lat = t.Lat,
            GarageContacts = t.GarageContacts?.Select(i => i.ToTable()).ToList(),
            GarageSocialLinks = t.GarageSocialLinks?.Select(i => i.ToTable()).ToList(),
            UserId = t.UserId,
            Long = t.Long,
            Description = t.Description,
            Address = t.Address,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UpdatedAt = t.UpdatedAt,
            UpdatedBy = t.UpdatedBy,
            DeletedBy = t.DeletedBy,
        };
}

public static class GarageContactTableExtensions
{
    public static GarageContactDto ToDto(this GarageContactEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Id = t.Id,
            PhoneNumber = t.PhoneNumber,
            Telegram = t.Telegram,
            WhatsApp = t.WhatsApp,
            WeChat = t.WeChat,
            GarageId = t.GarageId,
        };

    public static GarageContactEntity ToEntity(this GarageContactTable t) =>
        new()
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            PhoneNumber = t.PhoneNumber,
            Telegram = t.Telegram,
            WhatsApp = t.WhatsApp,
            WeChat = t.WeChat,
            GarageId = t.GarageId,
        };

    public static GarageContactEntity ToEntity(this GarageContactDto t) =>
        new()
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            PhoneNumber = t.PhoneNumber,
            Telegram = t.Telegram,
            WhatsApp = t.WhatsApp,
            WeChat = t.WeChat,
            GarageId = t.GarageId,
        };

    public static GarageContactTable ToTable(this GarageContactEntity t) =>
        new()
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            PhoneNumber = t.PhoneNumber,
            Telegram = t.Telegram,
            WhatsApp = t.WhatsApp,
            WeChat = t.WeChat,
            Garage = t.Garage?.ToTable(),
            GarageId = t.GarageId,
        };
}

public static class GarageSocialLinkTableExtensions
{
    public static GarageSocialLinkDto ToDto(this GarageSocialLinkEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Id = t.Id,
            SocialLink = t.SocialLink,
            SocialLinkType = t.SocialLinkType,
            GarageId = t.GarageId,
        };

    public static GarageSocialLinkEntity ToEntity(this GarageSocialLinkTable t) =>
        new()
        {

            Id = t.Id,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            SocialLinkType = t.SocialLinkType,
            GarageId = t.GarageId,
            SocialLink = t.SocialLink,
        };

    public static GarageSocialLinkEntity ToEntity(this GarageSocialLinkDto t) =>
        new()
        {

            Id = t.Id,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            SocialLinkType = t.SocialLinkType,
            GarageId = t.GarageId,
            SocialLink = t.SocialLink,
        };

    public static GarageSocialLinkTable ToTable(this GarageSocialLinkEntity t) =>
        new()
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            SocialLinkType = t.SocialLinkType,
            Garage = t.Garage?.ToTable(),
            GarageId = t.GarageId,
            SocialLink = t.SocialLink,
        };
}
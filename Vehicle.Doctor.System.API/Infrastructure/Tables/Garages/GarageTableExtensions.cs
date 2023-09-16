using Newtonsoft.Json;
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
            PhoneNumber = t.PhoneNumber,
            Telegram = t.Telegram,
            WeChat = t.WeChat,
            WhatsApp = t.WhatsApp,
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
            PhoneNumber = JsonConvert.DeserializeObject<List<string>>(t.PhoneNumber) ?? new List<string>(),
            Telegram = JsonConvert.DeserializeObject<List<string>>(t.Telegram ?? "[]") ?? new List<string>(),
            WeChat = JsonConvert.DeserializeObject<List<string>>(t.WeChat ?? "[]") ?? new List<string>(),
            WhatsApp = JsonConvert.DeserializeObject<List<string>>(t.WhatsApp ?? "[]") ?? new List<string>(),
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
            PhoneNumber = t.PhoneNumber,
            Telegram = t.Telegram,
            WeChat = t.WeChat,
            WhatsApp = t.WhatsApp,
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
            PhoneNumber = JsonConvert.SerializeObject(t.PhoneNumber),
            Telegram = JsonConvert.SerializeObject(t.Telegram),
            WeChat = JsonConvert.SerializeObject(t.WeChat),
            WhatsApp = JsonConvert.SerializeObject(t.WhatsApp),
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
using MediatR;
using Vehicle.Doctor.System.API.Applications.Entities.Garages;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Commands.CommandHandlers;

public class CreateGarageCommandHandler : IRequestHandler<CreateGarageCommand, GarageDto>
{
    private readonly IGarageRepository _repository;

    public CreateGarageCommandHandler(IGarageRepository repository)
    {
        _repository = repository;
    }

    public async Task<GarageDto> Handle(CreateGarageCommand request, CancellationToken cancellationToken)
    {
        var r = request.Garage;
        var garageEntity = new GarageEntity()
        {
            Id = 0,
            Address = r.Address,
            Description = r.Description,
            Lat = r.Lat,
            Long = r.Long,
            Name = r.Name,
            UserId = request.UserId,
            GarageContacts = r.GarageContacts?
                .Select(i => new GarageContactEntity()
                {
                    Id = 0,
                    PhoneNumber = i.PhoneNumber,
                    Telegram = i.Telegram,
                    WeChat = i.WeChat,
                    WhatsApp = i.WhatsApp,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }).ToList(),
            GarageSocialLinks = r.GarageSocialLinks?
                .Select(s => new GarageSocialLinkEntity()
                {
                    Id = 0,
                    SocialLink = s.SocialLink,
                    SocialLinkType = s.SocialLinkType,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }).ToList(),
        };
        var data = await _repository.CreateAsync(garageEntity, cancellationToken);
        return data.ToDto();
    }
}
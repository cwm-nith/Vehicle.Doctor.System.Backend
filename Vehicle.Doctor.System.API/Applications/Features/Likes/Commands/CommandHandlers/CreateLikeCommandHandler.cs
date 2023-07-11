using MediatR;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Commands.CommandHandlers;

public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, LikeDto>
{
    private readonly ILikeRepository _likeRepository;

    public CreateLikeCommandHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<LikeDto> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var data = await _likeRepository.CreateAsync(new LikeEntity()
        {
            GarageId = r.GarageId,
            LikerId = request.UserId,
            PosterId = r.PosterId,
            PostId = r.PostId
        }, cancellationToken);
        return data.ToDto();
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Likes.Commands;
using Vehicle.Doctor.System.API.Applications.Features.Likes.Queries;
using Vehicle.Doctor.System.Shared.Dto.Likes;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Controllers.V1.Posts;

[ApiVersion(ApiVersionConstant.V1)]
public class LikeController : BaseApiController
{
    private readonly IMediator _mediator;

    public LikeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetCountAsync(long postId, long garageId)
    {
        var count = await _mediator.Send(new GetCountQuery(postId, garageId, UserId));
        return Ok(count);
    }

    [HttpPost]
    public async Task<ActionResult<LikeDto>> AddLikeAsync([FromBody] CreateLikeDto dto)
    {
        var cmd = new CreateLikeCommand(dto, UserId);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [HttpDelete]
    public async Task<ActionResult<LikeDto>> DeleteLikeAsync(long id, long postId, long garageId)
    {
        var cmd = new DeleteLikeCommand(id, UserId, postId, garageId);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}
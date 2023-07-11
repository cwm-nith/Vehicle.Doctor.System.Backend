using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Likes.Queries;

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
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Posts.Commands;
using Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Controllers.V1.Posts;

[ApiVersion(ApiVersionConstant.V1)]
public class PostController : BaseApiController
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<PostDto>>> GetAsync([FromQuery] PagedQuery q)
    {
        var data = await _mediator.Send(new GetPostQuery(q));
        return Ok(data);
    }

    [HttpGet("by_user")]
    public async Task<ActionResult<PagedResult<PostDto>>> GetByUserAsync([FromQuery] PagedQuery q)
    {
        var data = await _mediator.Send(new GetPostByUserQuery(UserId, q));
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreateAsync([FromBody] CreatePostDto r)
    {
        var cmd = new CreatePostCommand(UserId, r);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}
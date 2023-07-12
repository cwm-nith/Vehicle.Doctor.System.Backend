using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Comments.Commands;
using Vehicle.Doctor.System.API.Applications.Features.Comments.Queries;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Comments;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Controllers.V1.Posts;

[ApiVersion(ApiVersionConstant.V1)]
public class CommentController : BaseApiController
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<int>> GetAsync([Required, FromQuery] long postId, [Required, FromQuery] long garageId, [FromQuery] PagedQuery q)
    {
        var count = await _mediator.Send(new GetCommentsQuery(postId, garageId, q));
        return Ok(count);
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> GetCountAsync([Required, FromQuery]long postId, [Required, FromQuery] long garageId)
    {
        var count = await _mediator.Send(new GetCommentCountQuery(postId, garageId));
        return Ok(count);
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateAsync([FromBody] CreateCommentDto r)
    {
        var data = await _mediator.Send(new CreateCommentCommand(UserId, r));
        return Ok(data);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteAsync([FromBody] DeleteCommentDto r)
    {
        var data = await _mediator.Send(new DeleteCommentCommand(UserId, r));
        return Ok(data);
    }
}
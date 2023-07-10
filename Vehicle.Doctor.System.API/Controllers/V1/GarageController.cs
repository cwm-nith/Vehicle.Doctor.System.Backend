using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Garages.Commands;
using Vehicle.Doctor.System.API.Applications.Features.Garages.Queries;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Controllers.V1;

[ApiVersion(ApiVersionConstant.V1)]
public class GarageController : BaseApiController
{
    private readonly IMediator _mediator;

    public GarageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<GarageDto>> GetAsync([FromQuery] PagedQuery q)
    {
        var data = await _mediator.Send(new GetGaragesQuery(q));
        return Ok(data);
    }

    [HttpGet("by_user")]
    public async Task<ActionResult<GarageDto>> GetByUserAsync([FromQuery] PagedQuery q)
    {
        var data = await _mediator.Send(new GetGaragesByUserQuery(UserId, q));
        return Ok(data);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GarageDto>> GetByIdAsync(long id)
    {
        var data = await _mediator.Send(new GetGarageByIdQuery(id, UserId));
        return Ok(data);
    }
    /// <summary>
    /// Social Link Type => None = 0, YouTube = 1, Facebook = 2, Instagram = 3, Twitter = 4, Tamneak = 5, Threads = 6, TikTok = 7,
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<GarageDto>> CreateAsync([FromBody] CreateGarageDto dto)
    {
        var cmd = new CreateGarageCommand(UserId, dto);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [HttpPut]
    public async Task<ActionResult<GarageDto>> UpdateAsync([FromBody] GarageDto r)
    {
        var cmd = new UpdateGarageCommand(r);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteAsync(long id)
    {
        var cmd = new DeleteGarageCommand(id, UserId);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}
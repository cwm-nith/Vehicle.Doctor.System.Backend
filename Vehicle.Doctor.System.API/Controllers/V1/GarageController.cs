using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.Controllers;
using Vehicle.Doctor.System.API.Applications.Features.Garages.Commands;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Controllers.V1;

[ApiVersion("1")]
public class GarageController : BaseApiController
{
    private readonly IMediator _mediator;

    public GarageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var a = await Task.FromResult("Hello");
        return Ok(a);
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
}
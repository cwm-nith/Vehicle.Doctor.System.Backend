using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Authentications.Commands;
using Vehicle.Doctor.System.API.Applications.Features.Users.Commands;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Controllers.V1;

[ApiVersion(ApiVersionConstant.V1)]
public class AuthController : BaseApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto r)
    {
        var cmd = new LoginCommand(r);
        var user = await _mediator.Send(cmd);
        return Ok(user);
    }

    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto dto)
    {
        var isChangedPassword = await _mediator.Send(new ChangePasswordCommand(dto, UserId));
        if(isChangedPassword) return Ok(new {Success = isChangedPassword});
        return BadRequest(new { Success = isChangedPassword });
    }
}
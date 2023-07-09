using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.Controllers;
using Vehicle.Doctor.System.API.Applications.Features.Authentications.Commands;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Controllers.V1;

[ApiVersion("1")]
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
}
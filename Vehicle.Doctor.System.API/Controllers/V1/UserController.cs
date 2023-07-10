using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Features.Users.Commands;
using Vehicle.Doctor.System.API.Applications.Features.Users.Queries;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Controllers.V1;

[ApiVersion(ApiVersionConstant.V1)]
public class UserController : BaseApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<PagedResult<UserDto>>> Get([FromQuery] PagedQuery q)
    {
        var query = new GetUserQuery()
        {
            Page = q.Page,
            Results = q.Results,
        };
        var data = await _mediator.Send(query);
        return Ok(data);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<UserDto>> GetUserById(long id)
    {
        var query = new GetUserByIdQuery(id);
        var data = await _mediator.Send(query);
        return data is not null? Ok(data) : NotFound();
    }

    [HttpGet("{username}/username")]
    public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
    {
        var query = new GetUserByNameQuery(username);
        var data = await _mediator.Send(query);
        return data is null ? NotFound() : Ok(data);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto body)
    {
        var cmd = new CreateUserCommand(body);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto body)
    {
        var cmd = new UpdateUserCommand
        {
            PhoneNumber = body.PhoneNumber,
            Id = id,
            Name = body.Name,
        };
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        var cmd = new DeleteUserCommand(id);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}
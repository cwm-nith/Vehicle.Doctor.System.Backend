using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Controllers;

[Route("/api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
    private const string ResourceHeader = "X-Resource";
    private const string IdentityHeader = "X-Identity";

    private long GetUserId()
    {
        var userId = User.Claims
            .FirstOrDefault(i => i.Type == ClaimsConstant.UserId)?.Value ?? "0";
        return long.Parse(userId);
    }

    protected long UserId => GetUserId();

    protected string UserRole
    {
        get
        {
            var pos = User?.FindFirst(ClaimTypes.Role)?.Value;
            return string.IsNullOrWhiteSpace(pos) ? "" : pos;
        }
    }

    protected ActionResult Accepted(string resource, string resourceId)
    {
        if (!string.IsNullOrWhiteSpace(resourceId))
        {
            Response.Headers.Append(ResourceHeader, $"{resource}/{resourceId}");
        }

        return base.Accepted();
    }

    protected ActionResult AcceptedWithResource(string resource, string identity)
    {
        if (string.IsNullOrWhiteSpace(resource))
        {
            return base.Accepted();
        }

        Response.Headers.Append(ResourceHeader, $"{resource}/{identity}");
        Response.Headers.Append(IdentityHeader, $"{identity}");

        return base.Accepted();
    }

    protected ActionResult OkWithResource(object obj, string resource, string identity)
    {
        if (string.IsNullOrWhiteSpace(resource))
        {
            return base.Ok(obj);
        }

        Response.Headers.Append(ResourceHeader, $"{resource}");
        Response.Headers.Append(IdentityHeader, $"{identity}");

        return base.Ok(obj);
    }
}
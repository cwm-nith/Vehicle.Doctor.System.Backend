using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Controllers.V1.Posts;

[ApiVersion(ApiVersionConstant.V1)]
public class CommentController : BaseApiController
{
    [HttpGet]
    public ActionResult GetAsync()
    {
        return Ok();
    }
}
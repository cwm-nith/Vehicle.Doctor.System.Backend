using Microsoft.AspNetCore.Mvc;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Controllers;

namespace NN.POS.System.API.Controllers.V2;

[ApiVersion(ApiVersionConstant.V2)]
public class TestV2Controller : BaseApiController
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new { Id = 3, Name = "nith v2" });
    }
}
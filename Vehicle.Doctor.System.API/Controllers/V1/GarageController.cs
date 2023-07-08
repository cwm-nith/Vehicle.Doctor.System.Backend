using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.Controllers;

namespace Vehicle.Doctor.System.API.Controllers.V1;

[ApiVersion("1")]
public class GarageController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var a = await Task.FromResult("Hello");
        return Ok(a);
    }
}
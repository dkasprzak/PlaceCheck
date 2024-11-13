using Microsoft.AspNetCore.Mvc;

namespace PlaceCheck.WebApi.Controllers;

[ApiController]
[Route("[action]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string GetHello()
    {
        return "Hello World!";
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Example02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IpController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IpController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    [HttpGet("local")]
    public string GetLocalIpAddress()
    {
        return IpService.GetLocalIpAddress(_httpContextAccessor.HttpContext);
    }

    [HttpGet("public")]
    public string GetPublicIpAddress()
    {
        return IpService.GetPublicIpAddress(_httpContextAccessor.HttpContext);
    }
}
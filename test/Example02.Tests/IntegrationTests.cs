using Alba;

namespace Example02.Tests;

public class IntegrationTests : IClassFixture<WebApiTestFixture>
{
    private readonly IAlbaHost _host;
    
    public IntegrationTests(WebApiTestFixture app)
    {
        _host = app.GetHost();
    }
    
    [Theory]
    [InlineData("/api/ip/local")]
    [InlineData("/api/ip/public")]
    public async Task Should_Get_Success_Response(string route)
    {
        await _host.Scenario(_ =>
        {
            _.Get.Url(route);
            _.StatusCodeShouldBeOk();
        });
    }
}
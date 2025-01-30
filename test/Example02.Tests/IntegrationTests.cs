using Alba;

namespace Example02.Tests;

public class IntegrationTests : IClassFixture<IntegrationTestsFixture>
{
    private readonly IAlbaHost _host;
    
    public IntegrationTests(IntegrationTestsFixture app)
    {
        _host = app.GetHost();
    }
    
    [Theory]
    [InlineData("/api/ip/local")]
    [InlineData("/api/ip/public")]
    public async Task Should_Get_Success_Response(string route)
    {
        await _host.Scenario(cfg =>
        {
            cfg.Get.Url(route);
            cfg.StatusCodeShouldBeOk();
        });
    }
}
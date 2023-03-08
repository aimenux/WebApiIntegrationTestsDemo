using Alba;

namespace Example02.Tests;

public class WebApiTestFixture : IAsyncLifetime
{
    private IAlbaHost _host;

    public async Task InitializeAsync()
    {
        _host = await AlbaHost.For<Program>(builder =>
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
            });
            
            builder.ConfigureServices((context, services) =>
            {
            });
        });
    }

    public IAlbaHost GetHost() => _host;

    public async Task DisposeAsync()
    {
        await _host.DisposeAsync();
    }
}
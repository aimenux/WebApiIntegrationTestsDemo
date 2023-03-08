using System.Net;
using FluentAssertions;

namespace Example01.Tests;

public class IntegrationTests
{
    [Theory]
    [InlineData("api/ip/local")]
    [InlineData("api/ip/public")]
    public async Task Should_Get_Success_Response(string route)
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
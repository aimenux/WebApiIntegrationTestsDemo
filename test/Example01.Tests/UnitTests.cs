using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Http;

namespace Example01.Tests;

public class UnitTests
{
    [Fact]
    public void Should_Get_Local_Ip_Address()
    {
        // arrange
        var context = new DefaultHttpContext
        {
            Connection =
            {
                LocalIpAddress = new IPAddress(16885952)
            }
        };
        
        // act
        var ip = IpService.GetLocalIpAddress(context);

        // assert
        ip.Should().Be("192.168.1.1");
    }
    
    [Fact]
    public void Should_Get_Public_Ip_Address()
    {
        // arrange
        var context = new DefaultHttpContext
        {
            Connection =
            {
                RemoteIpAddress = new IPAddress(16885952)
            }
        };
        
        // act
        var ip = IpService.GetPublicIpAddress(context);

        // assert
        ip.Should().Be("192.168.1.1");
    }
}
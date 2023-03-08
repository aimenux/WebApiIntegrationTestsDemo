using System.Net;
using Microsoft.Extensions.Primitives;

namespace Example01;

public static class IpService
{
    private const string IpNotFound = "ip not found";
    
    public static string GetLocalIpAddress(HttpContext context)
    {
        if (context.Connection.LocalIpAddress != null)
        {
            var localIpAddress = GetIpAddress(context.Connection.LocalIpAddress);
            return localIpAddress;            
        }

        return IpNotFound;  
    }
    
    public static string GetPublicIpAddress(HttpContext context)
    {
        var forwardedHeader = context.Request.Headers["X-Forwarded-For"];
        if (!StringValues.IsNullOrEmpty(forwardedHeader))
        {
            var remoteForwardedIpAddress = forwardedHeader.First();
            return remoteForwardedIpAddress;
        }

        if (context.Connection.RemoteIpAddress != null)
        {
            var remoteIpAddress = GetIpAddress(context.Connection.RemoteIpAddress);
            return remoteIpAddress;
        }

        return IpNotFound;  
    }

    private static string GetIpAddress(IPAddress ipAddress)
    {
        return ipAddress.IsIPv4MappedToIPv6 
            ? ipAddress.MapToIPv4().ToString() 
            : ipAddress.ToString();
    }
}
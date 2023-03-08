using Example01;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseForwardedHeaders();

app
    .MapGet("/api/ip/local", IpService.GetLocalIpAddress)
    .WithName("GetLocalIpAddress");

app
    .MapGet("/api/ip/public", IpService.GetPublicIpAddress)
    .WithName("GetPublicIpAddress");

app.Run();
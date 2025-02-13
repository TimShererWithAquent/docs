﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Add services to the container including logging
var services = new ServiceCollection();
services.AddLogging(builder => builder.AddConsole());
services.AddSingleton<ExampleService>();
IServiceProvider serviceProvider = services.BuildServiceProvider();

// Get the ExampleService object from the container
ExampleService service = serviceProvider.GetRequiredService<ExampleService>();

// Do some pretend work
service.DoSomeWork(10, 20);

class ExampleService
{
    private readonly ILogger<ExampleService> _logger;

    public ExampleService(ILogger<ExampleService> logger)
    {
        _logger = logger;
    }

    public void DoSomeWork(int x, int y)
    {
        _logger.LogInformation("DoSomeWork was called. x={X}, y={Y}", x, y);
    }
}

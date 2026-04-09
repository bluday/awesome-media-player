using AwesomeMediaPlayer;
using AwesomeMediaPlayer.Configuration;
using AwesomeMediaPlayer.UI.Extensions;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

using IHost host = Host.CreateDefaultBuilder()
    .UseContentRoot(AppContext.BaseDirectory)
    .ConfigureLogging(LoggingConfiguration.Configure)
    .ConfigureServices(ServiceConfiguration.Configure)
    .UseWinUI3Application<App>()
    .Build();

Ioc.Default.ConfigureServices(host.Services);

await host.RunAsync();
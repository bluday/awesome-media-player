using AwesomeMediaPlayer;
using AwesomeMediaPlayer.Configuration;
using AwesomeMediaPlayer.UI.Extensions;
using Microsoft.Extensions.Hosting;
using System;

using IHost host = Host.CreateDefaultBuilder()
    .UseContentRoot(AppContext.BaseDirectory)
    .ConfigureLogging(LoggingConfiguration.Configure)
    .ConfigureServices(ServiceConfiguration.Configure)
    .UseWinUI3Application<App>()
    .Build();

host.ConfigureCommunityToolkitIoc();

await host.RunAsync();
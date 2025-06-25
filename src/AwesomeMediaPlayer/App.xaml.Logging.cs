using Microsoft.Extensions.Logging;

namespace AwesomeMediaPlayer;

public sealed partial class App
{
    public static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging
            .AddConsole()
            .AddDebug();

        logging
            .SetMinimumLevel(LogLevel.Debug);
    }
}
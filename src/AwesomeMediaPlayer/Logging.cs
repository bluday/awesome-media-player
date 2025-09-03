using Microsoft.Extensions.Logging;

namespace AwesomeMediaPlayer;

/// <summary>
/// Provides logging configuration for the application, enabling console and debug logging.
/// </summary>
public static class Logging
{
    /// <summary>
    /// Configures logging services with console and debug output, and sets the minimum
    /// log level to <see cref="LogLevel.Debug"/>.
    /// </summary>
    /// <param name="logging">
    /// The logging builder used to configure logging services.
    /// </param>
    public static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging.AddConsole();
        logging.AddDebug();

        logging.SetMinimumLevel(LogLevel.Debug);
    }
}
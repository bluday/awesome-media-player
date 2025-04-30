namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the about view.
/// </summary>
public sealed partial class AboutViewModel : ObservableObject
{
    #region Properties
    /// <summary>
    /// Gets the raw Markdown text.
    /// </summary>
    public string Text { get; } = GetRawDefaultMarkdownText();
    #endregion

    /// <summary>
    /// Handles the link-clicked event by launching the provided URI.
    /// </summary>
    /// <param name="e">
    /// Contains the link that was clicked.
    /// </param>
    public async Task OnLinkClickedAsync(LinkClickedEventArgs e)
    {
        await Launcher.LaunchUriAsync(new Uri(e.Link));
    }

    public static string GetRawDefaultMarkdownText()
    {
        return @"VLC media player is a free and open source media player, encoder, and streamer made by the volunteers of the [VideoLAN](https://www.videolan.org/) community.
                        
VLC uses its internal codecs, works on essentially every popular platform, and can read almost all files, CDs, DVDs, network streams, capture cards and other media formats!
                        
[Help and join us!](https://www.videolan.org/contribute.html)";
    }
}
namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the media library view.
/// </summary>
public sealed partial class MediaLibraryViewModel
{
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
}
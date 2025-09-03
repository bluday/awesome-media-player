using CommunityToolkit.Mvvm.ComponentModel;

namespace AwesomeMediaPlayer.Data.ViewModels;

/// <summary>
/// Represents the view model for the about view.
/// </summary>
public sealed partial class AboutViewModel : ObservableObject
{
    /// <summary>
    /// Gets the raw Markdown text.
    /// </summary>
    public string Text { get; } = @"VLC media player is a free and open source media player, encoder, and streamer made by the volunteers of the [VideoLAN](https://www.videolan.org/) community.
                        
VLC uses its internal codecs, works on essentially every popular platform, and can read almost all files, CDs, DVDs, network streams, capture cards and other media formats!
                        
[Help and join us!](https://www.videolan.org/contribute.html)";
}
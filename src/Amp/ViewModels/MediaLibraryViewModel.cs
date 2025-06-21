using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinUI.UI.Controls;
using System;
using System.Threading.Tasks;
using Windows.System;

namespace Amp.ViewModels;

/// <summary>
/// Represents the view model for the media library view.
/// </summary>
public sealed partial class MediaLibraryViewModel : ObservableObject
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
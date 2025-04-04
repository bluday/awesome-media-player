﻿namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the help view.
/// </summary>
public sealed partial class AboutViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
    /// </summary>
    public AboutViewModel(WeakReferenceMessenger messenger) : base(messenger) { }

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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;

namespace AwesomeMediaPlayer.UI.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : ObservableObject
{
    #region Observable properties
    /// <summary>
    /// Gets the subtitle displayed in the title bar control.
    /// </summary>
    [ObservableProperty]
    public partial string? TitleBarSubtitle { get; private set; } = "Alpha";

    /// <summary>
    /// Gets the title displayed in the title bar control.
    /// </summary>
    [ObservableProperty]
    public partial string? TitleBarTitle { get; private set; } = "Awesome Media Player";

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    [ObservableProperty]
    public partial string? WindowTitle { get; private set; } = "Awesome Media Player";
    #endregion

    #region Instance properties
    /// <summary>
    /// Gets the view model for the media library view.
    /// </summary>
    public MediaLibraryViewModel MediaLibraryViewModel { get; }
    #endregion

    #region Instance constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/>
    /// class using the specified media library view model.
    /// </summary>
    /// <param name="mediaLibraryViewModel">
    /// The view model for the media library view.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="mediaLibraryViewModel"/> is <see langword="null"/>.
    /// </exception>
    public MainWindowViewModel(MediaLibraryViewModel mediaLibraryViewModel)
    {
        ArgumentNullException.ThrowIfNull(mediaLibraryViewModel);

        MediaLibraryViewModel = mediaLibraryViewModel;
    }
    #endregion

    #region Relay commands
    /// <summary>
    /// Closes the current window.
    /// </summary>
    [RelayCommand]
    public void CloseWindow()
    {
        // TODO: Send a message for closing the main window.
    }

    /// <summary>
    /// Creates a new window displays the about view.
    /// </summary>
    [RelayCommand]
    public void OpenAboutWindow()
    {
        // TODO: Send a message for opening the about window.
    }

    /// <summary>
    /// Creates a new window displays the current-media-information view.
    /// </summary>
    [RelayCommand]
    public void OpenCurrentMediaInformationWindow()
    {
        // TODO: Send a message for opening the current-media-information window.
    }

    /// <summary>
    /// Creates a new window displays the help view.
    /// </summary>
    [RelayCommand]
    public void OpenHelpWindow()
    {
        // TODO: Send a message for opening the help window.
    }

    /// <summary>
    /// Creates a new window displays the preferences view.
    /// </summary>
    [RelayCommand]
    public void OpenPreferencesWindow()
    {
        // TODO: Send a message for opening the preferences window.
    }
    #endregion
}
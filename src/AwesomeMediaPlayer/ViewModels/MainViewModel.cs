using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.IO;
using System.Windows.Input;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the main view.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    private ResourceLoader _resourceLoader;

    /// <summary>
    /// The absolute path for the title bar icon.
    /// </summary>
    public static readonly string TitleBarIconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "Icon-64.ico");

    /// <summary>
    /// Gets or sets the close window command.
    /// </summary>
    public ICommand? CloseWindowCommand { get; set; }

    /// <summary>
    /// Gets the view model for the media library view.
    /// </summary>
    public MediaLibraryViewModel MediaLibraryViewModel { get; private set; }

    /// <summary>
    /// Gets the subtitle for the view.
    /// </summary>
    public string? Subtitle { get; private set; }

    /// <summary>
    /// Gets the title for the view.
    /// </summary>
    public string? Title { get; private set; }

    /// <summary>
    /// Gets the icon image source for the title bar.
    /// </summary>
    public ImageSource? TitleBarIcon { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class using the view
    /// model for the media library view.
    /// </summary>
    /// <param name="mediaLibraryViewModel">
    /// The view model for the media library view.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="mediaLibraryViewModel"/> is <c>null</c>.
    /// </exception>
    public MainViewModel(MediaLibraryViewModel mediaLibraryViewModel)
    {
        ArgumentNullException.ThrowIfNull(mediaLibraryViewModel);

        _resourceLoader = new ResourceLoader();

        MediaLibraryViewModel = mediaLibraryViewModel;

        ApplyLocalizedContent();

        UpdateTitleBarIcon();
    }

    private void UpdateTitleBarIcon()
    {
        TitleBarIcon = new BitmapImage(new Uri(TitleBarIconPath));
    }

    /// <summary>
    /// Updates properties and fields with localized strings and content.
    /// </summary>
    public void ApplyLocalizedContent()
    {
        Title = _resourceLoader.GetString("General/AppDisplayName");
    }

    /// <summary>
    /// Creates a new window displays the about view.
    /// </summary>
    [RelayCommand]
    public void OpenAboutWindow()
    {
        return;
    }

    /// <summary>
    /// Creates a new window displays the help view.
    /// </summary>
    [RelayCommand]
    public void OpenHelpWindow()
    {
        return;
    }

    /// <summary>
    /// Creates a new window displays the preferences view.
    /// </summary>
    [RelayCommand]
    public void OpenPreferencesWindow()
    {
        return;
    }

    /// <summary>
    /// Creates a new window displays the current-media-information view.
    /// </summary>
    [RelayCommand]
    public void OpenCurrentMediaInformationWindow()
    {
        return;
    }
}
using AwesomeMediaPlayer.Windows;
using BluDay.Net.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Windows.Input;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the main view.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    private readonly ImplementationProvider<Window> _windowFactory;

    /// <summary>
    /// Gets the view model for the media library view.
    /// </summary>
    public MediaLibraryViewModel MediaLibraryViewModel { get; private set; }

    /// <summary>
    /// Gets or sets the close window command.
    /// </summary>
    public ICommand? CloseWindowCommand { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class using the view
    /// model for the media library view.
    /// </summary>
    /// <param name="mediaLibraryViewModel">
    /// The view model for the media library view.
    /// </param>
    /// <param name="windowFactory">
    /// The window factory.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="mediaLibraryViewModel"/> is null.
    /// </exception>
    public MainViewModel(
        MediaLibraryViewModel          mediaLibraryViewModel,
        ImplementationProvider<Window> windowFactory)
    {
        ArgumentNullException.ThrowIfNull(mediaLibraryViewModel);
        ArgumentNullException.ThrowIfNull(windowFactory);

        _windowFactory = windowFactory;

        MediaLibraryViewModel = mediaLibraryViewModel;
    }

    private void CreateWindow<TWindow>() where TWindow : Window
    {
        _windowFactory.GetInstance<TWindow>().Activate();
    }

    /// <summary>
    /// Activates a new <see cref="AboutWindow"/> instance and brings it to the foreground.
    /// </summary>
    [RelayCommand]
    public void OpenAboutWindow()
    {
        CreateWindow<AboutWindow>();
    }

    /// <summary>
    /// Activates a new <see cref="HelpWindow"/> instance and brings it to the foreground.
    /// </summary>
    [RelayCommand]
    public void OpenHelpWindow()
    {
        CreateWindow<HelpWindow>();
    }

    /// <summary>
    /// Activates a new <see cref="PreferencesWindow"/> instance and brings it to the foreground.
    /// </summary>
    [RelayCommand]
    public void OpenPreferencesWindow()
    {
        CreateWindow<PreferencesWindow>();
    }

    /// <summary>
    /// Activates a new <see cref="CurrentMediaInformationWindow"/> instance and brings it to the
    /// foreground.
    /// </summary>
    [RelayCommand]
    public void OpenCurrentMediaInformationWindow()
    {
        CreateWindow<CurrentMediaInformationWindow>();
    }
}
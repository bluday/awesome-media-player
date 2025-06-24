using Amp.Windows;
using BluDay.Net.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System.Windows.Input;

namespace Amp.ViewModels;

/// <summary>
/// Represents the view model for the main view.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    private readonly ImplementationProvider<Window> _windowFactory;

    /// <summary>
    /// Gets the media library view model instance.
    /// </summary>
    public MediaLibraryViewModel MediaLibraryViewModel { get; }

    /// <summary>
    /// Gets or sets the close window command.
    /// </summary>
    public ICommand? CloseWindowCommand { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="mediaLibraryViewModel">
    /// A transient media library view model instance.
    /// </param>
    /// <param name="windowFactory">
    /// A window factory.
    /// </param>
    public MainViewModel(
        MediaLibraryViewModel          mediaLibraryViewModel,
        ImplementationProvider<Window> windowFactory)
    {
        _windowFactory = windowFactory;

        MediaLibraryViewModel = mediaLibraryViewModel;
    }

    private TWindow CreateWindow<TWindow>() where TWindow : Window
    {
        TWindow window = _windowFactory.GetInstance<TWindow>();

        window.Activate();

        return window;
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
using AwesomeMediaPlayer.Windows;
using BluDay.Net.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System.Windows.Input;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the main view.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets the window factory instance for creating other windows.
    /// </summary>
    public ImplementationProvider<Window>? WindowFactory { get; set; }

    /// <summary>
    /// Gets or sets the close window command.
    /// </summary>
    public ICommand? CloseWindowCommand { get; set; }

    private TWindow CreateWindow<TWindow>() where TWindow : Window
    {
        if (WindowFactory is not ImplementationProvider<Window> windowFactory)
        {
            throw new System.InvalidOperationException("Window factory must be set.");
        }

        var window = windowFactory.GetInstance<TWindow>();

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
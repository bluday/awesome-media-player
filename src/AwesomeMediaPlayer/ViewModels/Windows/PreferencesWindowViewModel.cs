using BluDay.Net.WinUI3.Abstractions.ViewModels;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the preferences window.
/// </summary>
public sealed partial class PreferencesWindowViewModel : WindowViewModel
{
    private ResourceLoader _resourceLoader;

    /// <summary>
    /// Gets the current preferences view model instance.
    /// </summary>
    public PreferencesViewModel PreferencesViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesWindowViewModel"/> class.
    /// </summary>
    /// <param name="preferencesViewModel">
    /// The view model for the preferences view.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public PreferencesWindowViewModel(PreferencesViewModel preferencesViewModel, ResourceLoader resourceLoader)
    {
        _resourceLoader = resourceLoader;

        PreferencesViewModel = preferencesViewModel;
    }

    public override void ApplyDefaultIcon()
    {
        IconPath = System.IO.Path.Combine(AppContext.BaseDirectory, "Assets", "Icon-64.ico");
    }

    public override void ApplyDefaultPreActivationConfiguration()
    {
        ApplyDefaultIcon();
        ApplyDefaultTitle();
        ApplyDefaultSystemBackdrop();

        Resize(width: 1000, height: 1000);

        MoveToCenter();

        ExtendsContentIntoTitleBar = true;
    }

    public override void ApplyDefaultSystemBackdrop()
    {
        SystemBackdrop = new MicaBackdrop();
    }

    public override void ApplyDefaultTitle()
    {
        Title = _resourceLoader.GetString("PreferencesWindow/Title");
    }
}
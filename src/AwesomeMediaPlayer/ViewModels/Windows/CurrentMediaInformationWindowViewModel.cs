using BluDay.Net.WinUI3.Abstractions.ViewModels;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the current-media-information window.
/// </summary>
public sealed partial class CurrentMediaInformationWindowViewModel : WindowViewModel
{
    private ResourceLoader _resourceLoader;

    /// <summary>
    /// Gets the current current-media-information view model instance.
    /// </summary>
    public CurrentMediaInformationGeneralViewModel CurrentMediaInformationViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationWindowViewModel"/> class.
    /// </summary>
    /// <param name="currentMediaInformationViewModel">
    /// The view model for the current-media-information view.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public CurrentMediaInformationWindowViewModel(
        CurrentMediaInformationGeneralViewModel currentMediaInformationViewModel,
        ResourceLoader                          resourceLoader)
    {
        _resourceLoader = resourceLoader;

        CurrentMediaInformationViewModel = currentMediaInformationViewModel;
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

        Resize(width: 800, height: 700);

        MoveToCenter();

        ExtendsContentIntoTitleBar = true;
    }

    public override void ApplyDefaultSystemBackdrop()
    {
        SystemBackdrop = new MicaBackdrop();
    }

    public override void ApplyDefaultTitle()
    {
        Title = _resourceLoader.GetString("CurrentMediaInformationWindow/Title");
    }
}
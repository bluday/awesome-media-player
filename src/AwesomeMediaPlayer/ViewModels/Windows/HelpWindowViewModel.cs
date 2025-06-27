using BluDay.Net.WinUI3.Abstractions.ViewModels;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the help window.
/// </summary>
public sealed partial class HelpWindowViewModel : WindowViewModel
{
    private ResourceLoader _resourceLoader;

    /// <summary>
    /// Gets the current help view model instance.
    /// </summary>
    public HelpViewModel HelpViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpWindowViewModel"/> class.
    /// </summary>
    /// <param name="helpViewModel">
    /// The view model for the help view.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public HelpWindowViewModel(HelpViewModel helpViewModel, ResourceLoader resourceLoader)
    {
        _resourceLoader = resourceLoader;

        HelpViewModel = helpViewModel;
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

        Resize(width: 800, height: 800);

        MoveToCenter();

        ExtendsContentIntoTitleBar = true;
    }

    public override void ApplyDefaultSystemBackdrop()
    {
        SystemBackdrop = new MicaBackdrop();
    }

    public override void ApplyDefaultTitle()
    {
        Title = _resourceLoader.GetString("HelpWindow/Title");
    }
}
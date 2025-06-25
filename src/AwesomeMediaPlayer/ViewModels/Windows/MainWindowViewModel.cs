using BluDay.Net.WinUI3.Abstractions.ViewModels;
using BluDay.Net.WinUI3.Common;
using BluDay.Net.WinUI3.Extensions;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.IO;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : WindowViewModel, IApplicationResourceAware
{
    private ResourceLoader _resourceLoader;

    ResourceLoader IApplicationResourceAware.ResourceLoader => _resourceLoader;

    /// <summary>
    /// Gets the current main view model instance.
    /// </summary>
    public MainViewModel MainViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="mainViewModel">
    /// The view model for the main view.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public MainWindowViewModel(MainViewModel mainViewModel, ResourceLoader resourceLoader)
    {
        _resourceLoader = resourceLoader;

        mainViewModel.CloseWindowCommand = CloseCommand;

        MainViewModel = mainViewModel;
    }

    public override void ApplyDefaultIcon()
    {
        IconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "Icon-64.ico");
    }

    public override void ApplyDefaultPreActivationConfiguration()
    {
        ApplyDefaultIcon();
        ApplyDefaultTitle();
        ApplyDefaultSystemBackdrop();

        Resize(width: 1400, height: 1000);

        MoveToCenter();

        ExtendsContentIntoTitleBar = true;
    }

    public override void ApplyDefaultSystemBackdrop()
    {
        SystemBackdrop = new MicaBackdrop();
    }

    public override void ApplyDefaultTitle()
    {
        Title = this.GetLocalizedString("General/AppDisplayName");
    }
}
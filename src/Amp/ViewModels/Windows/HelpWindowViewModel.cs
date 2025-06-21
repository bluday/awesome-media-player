using BluDay.Net.WinUI3.Abstractions.ViewModels;
using BluDay.Net.WinUI3.Common;
using BluDay.Net.WinUI3.Extensions;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.IO;

namespace Amp.ViewModels;

/// <summary>
/// Represents the view model for the help window.
/// </summary>
public sealed partial class HelpWindowViewModel : WindowViewModel, IApplicationResourceAware
{
    private ResourceLoader _resourceLoader;

    ResourceLoader IApplicationResourceAware.ResourceLoader => _resourceLoader;

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

    /// <summary>
    /// Closes the window.
    /// </summary>
    [RelayCommand]
    public void CloseWindow()
    {
        Close();
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

        Resize(width: 600, height: 60);

        MoveToCenter();

        ExtendsContentIntoTitleBar = true;
    }

    public override void ApplyDefaultSystemBackdrop()
    {
        SystemBackdrop = new MicaBackdrop();
    }

    public override void ApplyDefaultTitle()
    {
        Title = this.GetLocalizedString("HelpWindow/Title");
    }
}
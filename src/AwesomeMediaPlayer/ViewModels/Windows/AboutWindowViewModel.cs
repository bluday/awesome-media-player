﻿using BluDay.Net.WinUI3.Abstractions.ViewModels;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the about window.
/// </summary>
public sealed partial class AboutWindowViewModel : WindowViewModel
{
    private ResourceLoader _resourceLoader;

    /// <summary>
    /// Gets the current about view model instance.
    /// </summary>
    public AboutViewModel AboutViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutWindowViewModel"/> class.
    /// </summary>
    /// <param name="aboutViewModel">
    /// The view model for the about view.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public AboutWindowViewModel(AboutViewModel aboutViewModel, ResourceLoader resourceLoader)
    {
        _resourceLoader = resourceLoader;

        AboutViewModel = aboutViewModel;
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

        Resize(width: 1100, height: 600);

        MoveToCenter();

        ExtendsContentIntoTitleBar = true;
    }

    public override void ApplyDefaultSystemBackdrop()
    {
        SystemBackdrop = new MicaBackdrop();
    }

    public override void ApplyDefaultTitle()
    {
        Title = _resourceLoader.GetString("AboutWindow/Title");
    }
}
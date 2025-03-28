﻿namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for an application shell.
/// </summary>
public sealed partial class ShellViewModel : Net.WinUI3.ViewModels.ShellViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">
    /// The navigation service.
    /// </param>
    /// <param name="messenger">
    /// The messaging service.
    /// </param>
    public ShellViewModel(
        IAppNavigationService  navigationService,
        WeakReferenceMessenger messenger
    )
        : base(navigationService, messenger) { }
}
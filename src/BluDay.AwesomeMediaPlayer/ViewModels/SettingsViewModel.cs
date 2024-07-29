﻿namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the <see cref="SettingsView"/> control.
/// </summary>
public sealed partial class SettingsViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
    /// </summary>
    public SettingsViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}
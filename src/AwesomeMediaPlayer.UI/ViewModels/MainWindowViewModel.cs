using AwesomeMediaPlayer.Infrastructure.Localization;
using System;

namespace AwesomeMediaPlayer.UI.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : WindowViewModel
{
    private readonly ILocalizedStringProvider _localizedStringProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class using
    /// the specified dependencies.
    /// </summary>
    /// <param name="localizedStringProvider">
    /// The resource provider used to access localized strings.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Throws if any of the parameters are <c>null</c>.
    /// </exception>
    public MainWindowViewModel(ILocalizedStringProvider localizedStringProvider)
    {
        ArgumentNullException.ThrowIfNull(localizedStringProvider);

        _localizedStringProvider = localizedStringProvider;
    }

    /// <summary>
    /// Applies localized content.
    /// </summary>
    public void ApplyLocalizedContent()
    {
        Subtitle = _localizedStringProvider.GetString("Common/Preview");
        Title    = _localizedStringProvider.GetString("General/AppDisplayName");
    }
}
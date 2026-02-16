using AwesomeMediaPlayer.Infrastructure.Localization;

namespace AwesomeMediaPlayer.UI.ViewModels.Windows;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : WindowViewModel
{
    private readonly ILocalizedStringProvider _localizedStringProvider;

    /// <summary>
    /// Gets the view model for the title bar control.
    /// </summary>
    public MainViewTitleBarViewModel TitleBar { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class using
    /// the resource provider for localized strings, and a cache service for resolving
    /// cached view model instances.
    /// </summary>
    /// <param name="localizedStringProvider">
    /// The resource provider used to access localized strings.
    /// </param>
    public MainWindowViewModel(ILocalizedStringProvider localizedStringProvider)
    {
        _localizedStringProvider = localizedStringProvider;

        TitleBar = MainViewTitleBarViewModel.Create();
    }

    /// <summary>
    /// Applies localized content.
    /// </summary>
    public void ApplyLocalizedContent()
    {
        MainViewTitleBarViewModel titleBar = TitleBar;

        titleBar.Subtitle = _localizedStringProvider.GetString("Common/Preview");
        titleBar.Title    = _localizedStringProvider.GetString("General/AppDisplayName");

        OnPropertyChanged(nameof(TitleBar));
    }
}
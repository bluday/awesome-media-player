using CommunityToolkit.Mvvm.ComponentModel;
using AwesomeMediaPlayer.Infrastructure.UI;

namespace AwesomeMediaPlayer.Data.ViewModels.Windows;

/// <summary>
/// Represents the base view model type for derived window view model types.
/// </summary>
public abstract partial class WindowViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets the currently displayed view.
    /// </summary>
    [ObservableProperty]
    public partial object? CurrentView { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the content extends into the title bar area.
    /// </summary>
    [ObservableProperty]
    public partial bool ExtendsContentIntoTitleBar { get; set; } = true;

    /// <summary>
    /// Gets or sets the current backdrop kind.
    /// </summary>
    [ObservableProperty]
    public partial BackdropKind BackdropKind { get; set; } = BackdropKind.Mica;

    /// <summary>
    /// Gets the title for the window.
    /// </summary>
    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;
}
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;

namespace AwesomeMediaPlayer.UI.ViewModels.Windows;

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
    /// Gets or sets a value indicating whether the content extends into the
    /// title bar area.
    /// </summary>
    [ObservableProperty]
    public partial bool ExtendsContentIntoTitleBar { get; set; } = true;

    /// <summary>
    /// Gets or sets the system backdrop.
    /// </summary>
    [ObservableProperty]
    public partial SystemBackdrop SystemBackdrop { get; set; } = new MicaBackdrop();

    /// <summary>
    /// Gets the title for the window.
    /// </summary>
    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;
}
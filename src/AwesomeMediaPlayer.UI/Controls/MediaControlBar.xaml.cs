using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Controls;

/// <summary>
/// Interaction logic for MediaControlBar.xaml.
/// </summary>
public sealed partial class MediaControlBar : UserControl
{
    #region Dependency properties
    /// <summary>
    /// Identifies the <see cref="CornerDragHandleVisibility"/> dependency
    /// property.
    /// </summary>
    public static readonly DependencyProperty CornerDragHandleVisibilityProperty = DependencyProperty.Register(
        nameof(CornerDragHandleVisibility),
        typeof(Visibility),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: Visibility.Visible)
    );
    #endregion

    #region Instance properties
    /// <summary>
    /// Gets or sets the visibility of the corner drag handle.
    /// </summary>
    public Visibility CornerDragHandleVisibility
    {
        get => (Visibility)GetValue(CornerDragHandleVisibilityProperty);
        set => SetValue(CornerDragHandleVisibilityProperty, value);
    }
    #endregion

    #region Instance constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MediaControlBar"/>
    /// class.
    /// </summary>
    public MediaControlBar()
    {
        InitializeComponent();
    }
    #endregion
}
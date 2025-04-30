namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the media control bar visible on the main view.
/// </summary>
public sealed partial class MediaControlBar : UserControl
{
    #region Dependency properties
    public static readonly DependencyProperty CornerDragHandleVisibilityProperty = DependencyProperty.Register(
        nameof(CornerDragHandleVisibility),
        typeof(Visibility),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: Visibility.Visible)
    );
    #endregion

    #region Properties
    public Visibility CornerDragHandleVisibility
    {
        get => (Visibility)GetValue(CornerDragHandleVisibilityProperty);
        set => SetValue(CornerDragHandleVisibilityProperty, value);
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaControlBar"/> class.
    /// </summary>
    public MediaControlBar() => InitializeComponent();
}
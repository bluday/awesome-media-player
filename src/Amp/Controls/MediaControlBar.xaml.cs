using Microsoft.UI.Xaml;

namespace Amp.Controls;

/// <summary>
/// Interaction logic for MediaControlBar.xaml.
/// </summary>
public sealed partial class MediaControlBar : Microsoft.UI.Xaml.Controls.UserControl
{
    public static readonly DependencyProperty CornerDragHandleVisibilityProperty = DependencyProperty.Register(
        nameof(CornerDragHandleVisibility),
        typeof(Visibility),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: Visibility.Visible)
    );

    public Visibility CornerDragHandleVisibility
    {
        get => (Visibility)GetValue(CornerDragHandleVisibilityProperty);
        set => SetValue(CornerDragHandleVisibilityProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaControlBar"/> class.
    /// </summary>
    public MediaControlBar()
    {
        InitializeComponent();
    }
}
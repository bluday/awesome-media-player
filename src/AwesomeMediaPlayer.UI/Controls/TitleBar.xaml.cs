using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace AwesomeMediaPlayer.UI.Controls;

/// <summary>
/// Represents a title bar control.
/// </summary>
public sealed partial class TitleBar : UserControl
{
    #region Dependency properties
    /// <summary>
    /// Identifies the <see cref="BackButtonVisibility"> dependency property.
    /// </summary>
    public static readonly DependencyProperty BackButtonVisibilityProperty = DependencyProperty.Register(
        nameof(BackButtonVisibility),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="HeaderVisibility"> dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderVisibilityProperty = DependencyProperty.Register(
        nameof(HeaderVisibility),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="MiddleContent"> dependency property.
    /// </summary>
    public static readonly DependencyProperty MiddleContentProperty = DependencyProperty.Register(
        nameof(MiddleContent),
        typeof(FrameworkElement),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="Icon"> dependency property.
    /// </summary>
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(ImageSource),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="Subtitle"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register(
        nameof(Subtitle),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: string.Empty)
    );

    /// <summary>
    /// Identifies the <see cref="Title"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: string.Empty)
    );
    #endregion

    #region Instance properties
    /// <summary>
    /// Gets or sets the root element on the middle.
    /// </summary>
    public FrameworkElement? MiddleContent
    {
        get => GetValue(MiddleContentProperty) as FrameworkElement;
        set => SetValue(MiddleContentProperty, value);
    }

    /// <summary>
    /// Gets or sets the visibility for the back button.
    /// </summary>
    public Visibility BackButtonVisibility
    {
        get => (Visibility)GetValue(BackButtonVisibilityProperty);
        set => SetValue(BackButtonVisibilityProperty, value);
    }

    /// <summary>
    /// Gets or sets the visibility for the header.
    /// </summary>
    public Visibility HeaderVisibility
    {
        get => (Visibility)GetValue(HeaderVisibilityProperty);
        set => SetValue(HeaderVisibilityProperty, value);
    }

    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    public ImageSource? Icon
    {
        get => GetValue(IconProperty) as ImageSource;
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// Gets or sets the subtitle text.
    /// </summary>
    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    /// <summary>
    /// Gets or sets the title text.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    #endregion

    #region Instance constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBar"/> class.
    /// </summary>
    public TitleBar()
    {
        InitializeComponent();
    }
    #endregion
}
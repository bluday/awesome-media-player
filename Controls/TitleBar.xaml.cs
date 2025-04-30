namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents an app window title bar.
/// </summary>
public sealed partial class TitleBar : UserControl
{
    #region Dependency properties
    /// <summary>
    /// Identifies the <see cref="TargetWindow"> dependency property.
    /// </summary>
    public static readonly DependencyProperty TargetWindowProperty = DependencyProperty.Register(
        nameof(TargetWindow),
        typeof(AppWindow),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="LeftContent"> dependency property.
    /// </summary>
    public static readonly DependencyProperty LeftContentProperty = DependencyProperty.Register(
        nameof(LeftContent),
        typeof(FrameworkElement),
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
    /// Identifies the <see cref="RightContent"> dependency property.
    /// </summary>
    public static readonly DependencyProperty RightContentProperty = DependencyProperty.Register(
        nameof(RightContent),
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
    /// Identifies the <see cref="HeaderMargin"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderMarginProperty = DependencyProperty.Register(
        nameof(HeaderMargin),
        typeof(Thickness),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: default)
    );

    /// <summary>
    /// Identifies the <see cref="HeaderVisibility"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderVisibilityProperty = DependencyProperty.Register(
        nameof(HeaderVisibility),
        typeof(Visibility),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: default)
    );

    /// <summary>
    /// Identifies the <see cref="Title"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );
    #endregion

    #region Properties
    /// <summary>
    /// Gets the targeted app window.
    /// </summary>
    public AppWindow? TargetWindow
    {
        get => GetValue(TargetWindowProperty) as AppWindow;
        set => SetValue(TargetWindowProperty, value);
    }

    /// <summary>
    /// Gets the root element on the left.
    /// </summary>
    public FrameworkElement? LeftContent
    {
        get => GetValue(LeftContentProperty) as FrameworkElement;
        set => SetValue(LeftContentProperty, value);
    }

    /// <summary>
    /// Gets the root element on the middle.
    /// </summary>
    public FrameworkElement? MiddleContent
    {
        get => GetValue(MiddleContentProperty) as FrameworkElement;
        set => SetValue(MiddleContentProperty, value);
    }

    /// <summary>
    /// Gets the root element on the right.
    /// </summary>
    public FrameworkElement? RightContent
    {
        get => GetValue(RightContentProperty) as FrameworkElement;
        set => SetValue(RightContentProperty, value);
    }

    /// <summary>
    /// Gets the image source for the icon.
    /// </summary>
    public ImageSource? Icon
    {
        get => GetValue(IconProperty) as ImageSource;
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// Gets the margin of the header.
    /// </summary>
    public Thickness HeaderMargin
    {
        get => (Thickness)GetValue(HeaderMarginProperty);
        set => SetValue(HeaderMarginProperty, value);
    }

    /// <summary>
    /// Gets the visibility of the header.
    /// </summary>
    public Visibility HeaderVisibility
    {
        get => (Visibility)GetValue(HeaderVisibilityProperty);
        set => SetValue(HeaderVisibilityProperty, value);
    }

    /// <summary>
    /// Gets the title value of the title bar.
    /// </summary>
    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBar"/> class.
    /// </summary>
    public TitleBar() => InitializeComponent();
}
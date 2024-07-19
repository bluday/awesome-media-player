namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the title bar control.
/// </summary>
public sealed partial class TitleBar : UserControl
{
    /// <summary>
    /// Gets the image source for the icon.
    /// </summary>
    public ImageSource? Icon
    {
        get => GetValue(IconProperty) as ImageSource;
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// Gets the title value of the title bar.
    /// </summary>
    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBar"/> class.
    /// </summary>
    public TitleBar() => InitializeComponent();
}

public sealed partial class TitleBar
{
    /// <summary>
    /// Identifies the Icon dependency property.
    /// </summary>
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(ImageSource),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the Title dependency property.
    /// </summary>
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );
}
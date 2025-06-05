namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Interaction logic for TitleBar.xaml.
/// </summary>
public sealed partial class TitleBar : UserControl
{
    #region Dependency properties
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
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBar"/> class.
    /// </summary>
    public TitleBar()
    {
        InitializeComponent();
    }
    #endregion
}
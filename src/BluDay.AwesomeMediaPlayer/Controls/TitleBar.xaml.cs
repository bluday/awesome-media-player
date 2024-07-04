namespace BluDay.AwesomeMediaPlayer.Controls;

public sealed partial class TitleBar : UserControl
{
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(ImageSource),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    public ImageSource? Icon
    {
        get => GetValue(IconProperty) as ImageSource;
        set => SetValue(IconProperty, value);
    }

    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    public TitleBar() => InitializeComponent();
}
namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the top menu bar of the application.
/// </summary>
public sealed partial class MenuBar : UserControl
{
    #region Dependency properties
    public static readonly DependencyProperty OpenHelpWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenHelpWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );
    #endregion

    #region Properties
    public ICommand OpenHelpWindowCommand
    {
        get => (ICommand)GetValue(OpenHelpWindowCommandProperty);
        set => SetValue(OpenHelpWindowCommandProperty, value);
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuBar"/> class.
    /// </summary>
    public MenuBar() => InitializeComponent();
}
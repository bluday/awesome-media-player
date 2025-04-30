namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the top menu bar of the application.
/// </summary>
public sealed partial class MenuBar : UserControl
{
    #region Dependency properties
    public static readonly DependencyProperty OpenAboutWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenAboutWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty OpenHelpWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenHelpWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty OpenPreferencesWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenPreferencesWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty QuitCommandProperty = DependencyProperty.Register(
        nameof(QuitCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the open about window command.
    /// </summary>
    public ICommand OpenAboutWindowCommand
    {
        get => (ICommand)GetValue(OpenAboutWindowCommandProperty);
        set => SetValue(OpenAboutWindowCommandProperty, value);
    }

    /// <summary>
    /// Gets or sets the open help window command.
    /// </summary>
    public ICommand OpenHelpWindowCommand
    {
        get => (ICommand)GetValue(OpenHelpWindowCommandProperty);
        set => SetValue(OpenHelpWindowCommandProperty, value);
    }

    /// <summary>
    /// Gets or sets the open preferences window command.
    /// </summary>
    public ICommand OpenPreferencesWindowCommand
    {
        get => (ICommand)GetValue(OpenPreferencesWindowCommandProperty);
        set => SetValue(OpenPreferencesWindowCommandProperty, value);
    }

    /// <summary>
    /// Gets or sets the quit command.
    /// </summary>
    public ICommand QuitCommand
    {
        get => (ICommand)GetValue(QuitCommandProperty);
        set => SetValue(QuitCommandProperty, value);
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuBar"/> class.
    /// </summary>
    public MenuBar() => InitializeComponent();
}
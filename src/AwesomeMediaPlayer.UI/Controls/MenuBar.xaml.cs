using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using System.Windows.Input;

namespace AwesomeMediaPlayer.UI.Controls;

/// <summary>
/// Interaction logic for MenuBar.xaml.
/// </summary>
public sealed partial class MenuBar : UserControl
{
    #region Dependency properties
    /// <summary>
    /// Identifies the <see cref="OpenAboutWindowCommandProperty"/> depdenency
    /// property.
    /// </summary>
    public static readonly DependencyProperty OpenAboutWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenAboutWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="OpenHelpWindowCommandProperty"/> depdenency
    /// property.
    /// </summary>
    public static readonly DependencyProperty OpenHelpWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenHelpWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="OpenPreferencesWindowCommandProperty"/> depdenency
    /// property.
    /// </summary>
    public static readonly DependencyProperty OpenPreferencesWindowCommandProperty = DependencyProperty.Register(
        nameof(OpenPreferencesWindowCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="QuitCommandProperty"/> depdenency
    /// property.
    /// </summary>
    public static readonly DependencyProperty QuitCommandProperty = DependencyProperty.Register(
        nameof(QuitCommand),
        typeof(ICommand),
        typeof(MenuBar),
        new PropertyMetadata(defaultValue: null)
    );
    #endregion

    #region Instance properties
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

    #region Instance constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuBar"/> class.
    /// </summary>
    public MenuBar()
    {
        InitializeComponent();
    }
    #endregion
}
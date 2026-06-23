using AwesomeMediaPlayer.UI.Windows;
using Microsoft.UI.Xaml;
using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App : Application
{
    #region Instance fields
    private readonly Func<MainWindow> _mainWindowFactory;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class using
    /// the specified dependencies.
    /// </summary>
    /// <param name="mainWindowFactory">
    /// The <see cref="MainWindow"/> factory.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when any of the parameters are <c>null</c>.
    /// </exception>
    public App(Func<MainWindow> mainWindowFactory)
    {
        ArgumentNullException.ThrowIfNull(mainWindowFactory);

        _mainWindowFactory = mainWindowFactory;

        InitializeComponent();
    }
    #endregion

    #region Instance methods
    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _mainWindowFactory().Activate();
    }
    #endregion
}
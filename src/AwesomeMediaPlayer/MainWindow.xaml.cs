using AwesomeMediaPlayer.UI.Extensions;
using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.Views;

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

using System;

namespace AwesomeMediaPlayer;

/// <summary>
/// Represents the main window.
/// </summary>
public sealed partial class MainWindow : Window
{
    #region Constants
    private const int MinimumHeight = 768;

    private const int MinimumWidth = 1024;
    #endregion

    #region Instance fields
    private double _dpiScaleFactor;
    #endregion

    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }
    #endregion

    #region Instance constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/>
    /// class using the specified view model.
    /// </summary>
    /// <param name="viewModel">
    /// The view model.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="viewModel"/> is <see langword="null"/>.
    /// </exception>
    public MainWindow(MainWindowViewModel viewModel, MediaLibraryView mediaLibraryView)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        ExtendsContentIntoTitleBar = true;

        ViewModel = viewModel;

        InitializeComponent();

        ConfigureAppWindow();

        SetTitleBar(TitleBar);

        ViewContentControl.Content = mediaLibraryView;
    }
    #endregion

    #region Instance methods
    private void ConfigureAppWindow()
    {
        AppWindow appWindow = AppWindow;

        if (appWindow.Presenter is not OverlappedPresenter presenter)
        {
            presenter = OverlappedPresenter.Create();

            appWindow.SetPresenter(presenter);
        }

        _dpiScaleFactor = this.GetCurrentDpiScaleFactor();

        int scaledMinimumHeight = (int)(MinimumHeight * _dpiScaleFactor);
        int scaledMinimumWidth  = (int)(MinimumWidth  * _dpiScaleFactor);

        presenter.PreferredMinimumWidth  = scaledMinimumWidth;
        presenter.PreferredMinimumHeight = scaledMinimumHeight;

        appWindow.Resize(scaledMinimumWidth, scaledMinimumHeight);
        appWindow.MoveToCenter();
        appWindow.SetIcon(Icons.WindowIcon.FullName);
    }
    #endregion
}
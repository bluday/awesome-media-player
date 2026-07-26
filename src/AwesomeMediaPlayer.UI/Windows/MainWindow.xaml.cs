using AwesomeMediaPlayer.UI.Extensions;
using AwesomeMediaPlayer.UI.ViewModels;
using AwesomeMediaPlayer.UI.Windowing;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.IO;

namespace AwesomeMediaPlayer.UI.Windows;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    #region Constants
    /// <summary>
    /// The minimum height, in pixels.
    /// </summary>
    public const int MinimumHeight = 768;

    /// <summary>
    /// The minimum width, in pixels.
    /// </summary>
    public const int MinimumWidth = 1024;
    #endregion

    #region Static fields
    /// <summary>
    /// The absolute path for the title bar icon.
    /// </summary>
    public static readonly string IconPath = Path.Combine(
        AppContext.BaseDirectory,
        "Assets",
        "icon_64.ico"
    );
    #endregion

    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        ExtendsContentIntoTitleBar = true;

        ViewModel = Ioc.Default.GetRequiredService<MainWindowViewModel>();

        SetTitleBar(TitleBar);

        InitializeComponent();
    }
    #endregion

    #region Event handlers
    private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
    {
        RefreshTitleBarColors(LayoutRoot.RequestedTheme);
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

        double dpiScaleFactor = this.GetCurrentDpiScaleFactor();

        int scaledMinimumHeight = (int)(MinimumHeight * dpiScaleFactor);
        int scaledMinimumWidth  = (int)(MinimumWidth  * dpiScaleFactor);

        presenter.PreferredMinimumWidth  = scaledMinimumWidth;
        presenter.PreferredMinimumHeight = scaledMinimumHeight;

        appWindow.Resize(scaledMinimumWidth, scaledMinimumHeight);
        appWindow.MoveToCenter();
        appWindow.SetIcon(IconPath);
    }

    private void RefreshTitleBarColors(ElementTheme elementTheme)
    {
        if (elementTheme is ElementTheme.Light)
        {
            AppWindowConfigurator.ApplyLightTitleBarColors(AppWindow);
        }
        else
        {
            AppWindowConfigurator.ApplyDarkTitleBarColors(AppWindow);
        }
    }

    /// <inheritdoc/>
    public void ApplyConfiguration()
    {
        ConfigureAppWindow();

        if (ViewModel is not MainWindowViewModel viewModel)
        {
            return;
        }

        viewModel.IconUri = new Uri(IconPath);

        ResourceLoader resourceLoader = new();

        viewModel.Subtitle = resourceLoader.GetString("Common/Preview");
        viewModel.Title    = resourceLoader.GetString("General/AppDisplayName");
    }
    #endregion
}
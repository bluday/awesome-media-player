using AwesomeMediaPlayer.UI.Common.Extensions;
using AwesomeMediaPlayer.UI.ViewModels.Windows;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using Windows.Graphics;
using Windows.UI;

namespace AwesomeMediaPlayer.UI.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
public sealed partial class MainWindow : Window
{
    #region Constants
    /// <summary>
    /// Reduction factor applied when a scaled dimension value exceeds the
    /// display work area.
    /// </summary>
    public const double DISPLAY_WORK_AREA_OVERFLOW_REDUCTION_FACTOR = 0.9;

    /// <summary>
    /// The minimum height in pixels, unscaled.
    /// </summary>
    public const int MINIMUM_UNSCALED_HEIGHT = 768;

    /// <summary>
    /// The minimum width in pixels, unscaled.
    /// </summary>
    public const int MINIMUM_UNSCALED_WIDTH = 1024;
    #endregion

    #region Fields
    private readonly double _dpiScaleFactor;

    private readonly RectInt32 _displayWorkArea;
    #endregion

    #region Properties
    /// <summary>
    /// Gets a value indicating whether the window has been closed.
    /// </summary>
    public bool HasClosed { get; private set; }

    /// <summary>
    /// Gets or sets the view model instance associated with this window type.
    /// </summary>
    public MainWindowViewModel? ViewModel { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        _displayWorkArea = DisplayArea
            .GetFromWindowId(AppWindow.Id, DisplayAreaFallback.None)
            .WorkArea;

        _dpiScaleFactor = this.GetCurrentDpiScaleFactor();

        ExtendsContentIntoTitleBar = true;

        SetTitleBar(titleBar);

        ConfigureNativeWindow();
        ConfigureNativeTitleBar();

        InitializeComponent();
    }
    #endregion

    #region Methods
    private int GetScaledMinimumHeight()
    {
        return (int)Math.Min(
            MINIMUM_UNSCALED_HEIGHT * _dpiScaleFactor,
            _displayWorkArea.Height * DISPLAY_WORK_AREA_OVERFLOW_REDUCTION_FACTOR
        );
    }

    private int GetScaledMinimumWidth()
    {
        return (int)Math.Min(
            MINIMUM_UNSCALED_WIDTH * _dpiScaleFactor,
            _displayWorkArea.Width * DISPLAY_WORK_AREA_OVERFLOW_REDUCTION_FACTOR
        );
    }

    private void RefreshTitleBarColors(ElementTheme elementTheme)
    {
        if (!AppWindowTitleBar.IsCustomizationSupported())
        {
            return;
        }

        AppWindowTitleBar titleBar = AppWindow.TitleBar;

        Color buttonForegroundColor;
        Color hoverPressedBackgroundColor;

        titleBar.ButtonBackgroundColor = Colors.Transparent;
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

        if (elementTheme is ElementTheme.Light)
        {
            hoverPressedBackgroundColor = Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD);

            buttonForegroundColor = Colors.Black;
        }
        else
        {
            hoverPressedBackgroundColor = Color.FromArgb(0xFF, 0x33, 0x33, 0x33);

            buttonForegroundColor = Colors.White;
        }

        titleBar.ButtonHoverBackgroundColor = hoverPressedBackgroundColor;
        titleBar.ButtonPressedBackgroundColor = hoverPressedBackgroundColor;

        titleBar.ButtonForegroundColor = buttonForegroundColor;
        titleBar.ButtonHoverForegroundColor = buttonForegroundColor;
        titleBar.ButtonPressedForegroundColor = buttonForegroundColor;
    }

    /// <summary>
    /// Configures the underlying, native title bar for the window.
    /// </summary>
    public void ConfigureNativeTitleBar()
    {
        AppWindow.SetIcon("ms-appx:///Assets/Icon-64.ico");
    }

    /// <summary>
    /// Configures the underlying native window.
    /// </summary>
    public void ConfigureNativeWindow()
    {
        AppWindow appWindow = AppWindow;

        if (appWindow.Presenter is not OverlappedPresenter presenter)
        {
            presenter = OverlappedPresenter.Create();

            appWindow.SetPresenter(presenter);
        }

        if (ViewModel is MainWindowViewModel viewModel)
        {
            viewModel.ExtendsContentIntoTitleBar = ExtendsContentIntoTitleBar;
            viewModel.SystemBackdrop             = SystemBackdrop;
        }

        int scaledHeight = GetScaledMinimumHeight();
        int scaledWidth = GetScaledMinimumWidth();

        presenter.PreferredMinimumWidth  = scaledWidth;
        presenter.PreferredMinimumHeight = scaledHeight;

        appWindow.Resize(scaledWidth, scaledHeight);
        appWindow.MoveToCenter();
    }
    #endregion

    #region Event handlers
    private void Window_Closed(object sender, WindowEventArgs args)
    {
        HasClosed = true;
    }
    #endregion
}
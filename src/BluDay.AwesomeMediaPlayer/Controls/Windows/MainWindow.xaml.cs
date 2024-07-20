using Microsoft.UI;
using Microsoft.UI.Windowing;

using Windows.Graphics;

namespace BluDay.AwesomeMediaPlayer.Controls.Windows;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private DisplayArea _displayArea;

    private string? _iconPath;

    private readonly AppWindow _appWindow;

    private readonly AppWindowTitleBar _appWindowTitleBar;

    /// <summary>
    /// Gets the app icon path for the title bar.
    /// </summary>
    public string? IconPath
    {
        get => _iconPath;
        set
        {
            _iconPath = value;

            _appWindow.SetIcon(_iconPath);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the content extends into the title bar area.
    /// </summary>
    public new bool ExtendsContentIntoTitleBar
    {
        get => _appWindowTitleBar.ExtendsContentIntoTitleBar;
        set
        {
            _appWindowTitleBar.ExtendsContentIntoTitleBar = value;

            if (value)
            {
                ShowCustomTitleBar();

                return;
            }

            ShowDefaultTitleBar();
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        _displayArea = null!;

        _appWindow = AppWindow;

        _appWindowTitleBar = _appWindow.TitleBar;

        UpdateDisplayArea();

        InitializeComponent();
    }

    /// <summary>
    /// Shows the custom <see cref="TitleBar"/> control and hides the default Win32 title bar.
    /// </summary>
    private void ShowCustomTitleBar()
    {
        TitleBar.Visibility = Visibility.Visible;

        _appWindowTitleBar.BackgroundColor
            = _appWindowTitleBar.ButtonBackgroundColor
            = _appWindowTitleBar.ButtonInactiveBackgroundColor
            = Colors.Transparent;

        SetTitleBar(TitleBar);
    }

    /// <summary>
    /// Shows the defualt Win32 title bar and hides the custom <see cref="TitleBar"/> control.
    /// </summary>
    private void ShowDefaultTitleBar()
    {
        TitleBar.Visibility = Visibility.Collapsed;

        _appWindowTitleBar.ResetToDefault();

        _appWindow.SetIcon(_iconPath);
    }

    /// <summary>
    /// Gets the current <see cref="DisplayArea"/> for this window and updates
    /// <see cref="_displayArea"/> with the new instance.
    /// </summary>
    private void UpdateDisplayArea()
    {
        _displayArea = DisplayArea.GetFromWindowId(_appWindow.Id, DisplayAreaFallback.Nearest);
    }

    /// <summary>
    /// Moves the window to the provided x and y coordinates on the screen.
    /// </summary>
    /// <param name="x">
    /// The x coordinate.
    /// </param>
    /// <param name="y">
    /// The y coordinate.
    /// </param>
    public void Move(int x, int y)
    {
        _appWindow.Move(new PointInt32(x, y));
    }

    /// <summary>
    /// Centers the window on the default <see cref="_displayArea"/>.
    /// </summary>
    public void MoveToCenter()
    {
        MoveToCenter(_displayArea);
    }

    /// <summary>
    /// Centers the window on the provided <paramref name="displayArea"/>.
    /// </summary>
    /// <param name="displayArea">
    /// A <see cref="DisplayArea"/> instance of the targeted display.
    /// </param>
    public void MoveToCenter(DisplayArea displayArea)
    {
        int x = (displayArea.WorkArea.Width - _appWindow.Size.Width) / 2;
        int y = (displayArea.WorkArea.Height - _appWindow.Size.Height) / 2;

        Move(x, y);
    }

    /// <summary>
    /// Resizes the window using the provided width and height integer values.
    /// </summary>
    /// <param name="width">
    /// The width of the window.
    /// </param>
    /// <param name="height">
    /// The height of the window.
    /// </param>
    public void Resize(int width, int height)
    {
        _appWindow.Resize(new SizeInt32(width, height));
    }
}
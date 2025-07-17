using AwesomeMediaPlayer.Data.ViewModels;
using BluDay.Net.WinUI3.Extensions;
using Microsoft.UI.Xaml;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MainView.xaml.
/// </summary>
public sealed partial class MainView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    public MainView()
    {
        InitializeComponent();
    }

    public void ConfigureWindow(Window window)
    {
        window.ExtendsContentIntoTitleBar = true;
        window.Title                      = (DataContext as MainViewModel)?.Title;
        window.SystemBackdrop             = new Microsoft.UI.Xaml.Media.MicaBackdrop();

        Microsoft.UI.Windowing.AppWindow appWindow = window.AppWindow;

        appWindow.Resize(1600, 1200);

        appWindow.MoveToCenter();
    }
}
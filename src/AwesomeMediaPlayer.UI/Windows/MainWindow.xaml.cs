using AwesomeMediaPlayer.UI.ViewModels.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.Graphics;

namespace AwesomeMediaPlayer.UI.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
public sealed partial class MainWindow : Window
{
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        ViewModel = Ioc.Default.GetRequiredService<MainWindowViewModel>();

        InitializeComponent();
    }

    public void ApplyDefaultConfiguration()
    {
        ExtendsContentIntoTitleBar = true;

        SystemBackdrop = new MicaBackdrop();

        if (ViewModel is MainWindowViewModel viewModel)
        {
            viewModel.ExtendsContentIntoTitleBar = ExtendsContentIntoTitleBar;
            viewModel.SystemBackdrop             = SystemBackdrop;
        }

        SizeInt32 size = new(1600, 1200);

        RectInt32 workArea = DisplayArea
            .GetFromWindowId(AppWindow.Id, DisplayAreaFallback.Primary)
            .WorkArea;

        AppWindow.Resize(size);

        AppWindow.Move(new PointInt32(
            (workArea.Width - size.Width) / 2,
            (workArea.Height - size.Height) / 2
        ));
    }
}
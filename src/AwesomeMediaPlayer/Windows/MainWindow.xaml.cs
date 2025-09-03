using AwesomeMediaPlayer.Data.ViewModels;
using AwesomeMediaPlayer.Data.ViewModels.Windows;
using AwesomeMediaPlayer.Extensions;
using AwesomeMediaPlayer.Infrastructure.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;

namespace AwesomeMediaPlayer.Windows;

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
    /// Initializes a new instance of the <see cref="MainWindow"/> class using the specified,
    /// corresponding view model instance.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="viewModel"/> is <c>null</c>.
    /// </exception>
    public MainWindow(MainWindowViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        ViewModel = viewModel;

        InitializeComponent();
    }

    public void ApplyDefaultConfiguration()
    {
        ExtendsContentIntoTitleBar = true;

        SystemBackdrop = new Microsoft.UI.Xaml.Media.MicaBackdrop();

        if (ViewModel is MainWindowViewModel viewModel)
        {
            viewModel.BackdropKind = BackdropKind.Mica;

            viewModel.ExtendsContentIntoTitleBar = ExtendsContentIntoTitleBar;
        }

        AppWindow.Resize(width: 1600, height: 1200);

        AppWindow.MoveToCenter();
    }
}
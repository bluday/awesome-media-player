using Amp.ViewModels;
using Microsoft.UI.Xaml;

namespace Amp.Windows;

/// <summary>
/// Represents a window can be used independently or within a Frame for navigation.
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
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public MainWindow(MainWindowViewModel viewModel)
    {
        viewModel.SetWindow(this);

        viewModel.ApplyDefaultPreActivationConfiguration();

        viewModel.TitleBarControl = AppTitleBar;

        ViewModel = viewModel;

        InitializeComponent();
    }
}
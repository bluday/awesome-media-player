using Amp.ViewModels;
using Microsoft.UI.Xaml;

namespace Amp.Windows;

/// <summary>
/// Represents the about window control.
/// </summary>
public sealed partial class AboutWindow : Window
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public AboutWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public AboutWindow(AboutWindowViewModel viewModel)
    {
        viewModel.SetWindow(this);

        viewModel.ApplyDefaultPreActivationConfiguration();

        viewModel.TitleBarControl = AppTitleBar;

        ViewModel = viewModel;

        InitializeComponent();
    }
}
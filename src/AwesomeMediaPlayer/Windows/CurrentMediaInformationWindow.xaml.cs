using AwesomeMediaPlayer.ViewModels;
using Microsoft.UI.Xaml;

namespace AwesomeMediaPlayer.Windows;

/// <summary>
/// Represents a window can be used independently or within a Frame for navigation.
/// </summary>
public sealed partial class CurrentMediaInformationWindow : Window
{
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public CurrentMediaInformationWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public CurrentMediaInformationWindow(CurrentMediaInformationWindowViewModel viewModel)
    {
        viewModel.SetWindow(this);

        viewModel.ApplyDefaultPreActivationConfiguration();

        viewModel.TitleBarControl = AppTitleBar;

        ViewModel = viewModel;

        InitializeComponent();
    }
}
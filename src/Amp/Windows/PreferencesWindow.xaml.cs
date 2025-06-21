using Amp.ViewModels;
using Microsoft.UI.Xaml;

namespace Amp.Windows;

/// <summary>
/// Represents a window can be used independently or within a Frame for navigation.
/// </summary>
public sealed partial class PreferencesWindow : Window
{
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public PreferencesWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public PreferencesWindow(PreferencesWindowViewModel viewModel)
    {
        viewModel.SetWindow(this);

        viewModel.ApplyDefaultPreActivationConfiguration();

        viewModel.TitleBarControl = AppTitleBar;

        ViewModel = viewModel;

        InitializeComponent();
    }
}
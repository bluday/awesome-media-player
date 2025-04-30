namespace BluDay.AwesomeMediaPlayer.Controls.Windows;

/// <summary>
/// Represents a customizable shell window that hosts and manages a view model.
/// This window can be used independently or within a Frame for navigation.
/// </summary>
public sealed partial class MainWindow : Window
{
    #region Properties
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public MainWindow(MainWindowViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);
    }
}
namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the about window control.
/// </summary>
public sealed partial class AboutWindow : Window
{
    #region Properties
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public AboutWindowViewModel ViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public AboutWindow(AboutWindowViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);
    }
}
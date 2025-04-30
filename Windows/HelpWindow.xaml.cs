namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the help window control.
/// </summary>
public sealed partial class HelpWindow : Window
{
    #region Properties
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public HelpWindowViewModel ViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The corresponding view model instance as a transient.
    /// </param>
    public HelpWindow(HelpWindowViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);
    }
}
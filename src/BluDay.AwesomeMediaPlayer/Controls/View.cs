namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents the non-instantiatable base view model class.
/// </summary>
public abstract partial class View : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ViewModel"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient view model instance.
    /// </param>
    public View(ViewModel viewModel)
    {
        DataContext = viewModel;
    }
}
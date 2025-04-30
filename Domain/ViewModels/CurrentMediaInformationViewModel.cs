namespace BluDay.AwesomeMediaPlayer.Domain.ViewModels;

/// <summary>
/// Represents the view model class for the current media information view.
/// </summary>
public sealed partial class CurrentMediaInformationViewModel : ObservableObject
{
    #region Properties
    /// <summary>
    /// Gets or sets the close window command.
    /// </summary>
    public ICommand? CloseWindowCommand { get; set; }
    #endregion

    /// <summary>
    /// Initialize a new instance of the <see cref="CurrentMediaInformationViewModel"/> class.
    /// </summary>
    public CurrentMediaInformationViewModel()
    {
        // TODO: Set fields and properties.
    }
}
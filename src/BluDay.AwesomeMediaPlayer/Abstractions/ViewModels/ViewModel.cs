namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the non-instantiatable base view model class.
/// </summary>
public abstract partial class ViewModel : ObservableObject
{
    protected ViewModel? _currentChild;

    protected readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets the current child instance.
    /// </summary>
    public ViewModel? CurrentChild
    {
        get => _currentChild;
        protected set
        {
            _currentChild = value;

            // TODO: Deactivate the previous one and activate the new one.

            OnPropertyChanged(nameof(CurrentChild));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// An instance of a <see cref="WeakReference"/>-based messenger.
    /// </param>
    public ViewModel(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;
    }
}
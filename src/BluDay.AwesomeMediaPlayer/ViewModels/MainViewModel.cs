namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the <see cref="MainView"/> control.
/// </summary>
public sealed partial class MainViewModel : ViewModel
{
    private NavigationView _navigationViewControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    public MainViewModel(WeakReferenceMessenger messenger) : base(messenger)
    {
        _navigationViewControl = null!;
    }

    /// <summary>
    /// Sets the targeted navigation view control for the view.
    /// </summary>
    /// <param name="navigationView">
    /// The navigation view control.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="navigationView"/> is null.
    /// </exception>
    public void SetNavigationView(NavigationView navigationView)
    {
        ArgumentNullException.ThrowIfNull(navigationView);

        _navigationViewControl = navigationView;

        // TODO: Register event handlers manually here, or in XAML using Behaviors?
    }
}
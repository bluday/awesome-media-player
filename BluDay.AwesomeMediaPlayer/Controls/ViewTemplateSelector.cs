namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents a data template selector for parameterless view controls.
/// </summary>
public sealed partial class ViewTemplateSelector : DataTemplateSelector
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewTemplateSelector"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    /// The root service provider instance. Temporary solution for resolving view instances.
    /// </param>
    public ViewTemplateSelector(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        return base.SelectTemplateCore(item, container);
    }
}
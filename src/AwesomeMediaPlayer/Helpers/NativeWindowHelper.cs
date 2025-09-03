using System.Runtime.InteropServices;

namespace AwesomeMediaPlayer.Helpers;

/// <summary>
/// Provides helper methods and constants for interacting with and managing native window
/// instances via Win32 interop.
/// </summary>
public static class NativeWindowHelper
{
    /// <summary>
    /// The standard DPI (dots per inch) value used for 1:1 scaling on most displays.
    /// Commonly used as a baseline for DPI-aware calculations.
    /// </summary>
    public const double STANDARD_DPI = 96.0;

    /// <summary>
    /// Retrieves or sets the parent window handle using the <c>GetWindowLongPtr</c> or
    /// <c>SetWindowLongPtr</c> function with this index value.
    /// </summary>
    public const int GWLP_HWNDPARENT = -8;

    /// <summary>
    /// Retrieves the DPI awareness context for a specified window handle.
    /// </summary>
    /// <param name="hwnd">
    /// The handle of the window to query.
    /// </param>
    /// <returns>
    /// The DPI value associated with the window, typically used for scaling calculations.
    /// </returns>
    [DllImport("user32.dll")]
    public static extern int GetDpiForWindow(nint hwnd);

    /// <summary>
    /// Updates the specified attribute of a window using a new value.
    /// </summary>
    /// <param name="hWnd">
    /// The handle of the window whose attribute is being modified.
    /// </param>
    /// <param name="nIndex">
    /// The zero-based offset to the value to be set (e.g., <see cref="GWLP_HWNDPARENT"/>).
    /// </param>
    /// <param name="dwNewLong">
    /// The replacement value for the specified window attribute.
    /// </param>
    /// <returns>
    /// The previous value of the specified attribute.
    /// </returns>
    [DllImport("user32.dll")]
    public static extern nint SetWindowLongPtr(nint hWnd, int nIndex, nint dwNewLong);
}
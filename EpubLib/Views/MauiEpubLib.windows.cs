using Microsoft.UI.Xaml.Controls;
using Grid = Microsoft.UI.Xaml.Controls.Grid;
namespace EpubLib.Views;

/// <summary>
/// Represents a cross-platform EPUB reader control that can be used in .NET MAUI applications.
/// </summary>
public partial class MauiEpubLib : Grid
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MauiEpubLib"/> class with the specified <see cref="WebView"/> control.
	/// </summary>
	/// <param name="epubLib"></param>
	public MauiEpubLib(WebView2 epubLib)
	{
		Children.Add(epubLib);
	}
}

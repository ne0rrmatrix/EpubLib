using Microsoft.Maui.Handlers;
using UIKit;
using WebKit;

namespace EpubLib.Views;

/// <summary>
/// Represents a custom view for displaying EPUB content in a .NET MAUI application on iOS.
/// </summary>
public partial class MauiEpubLib : UIView
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MauiEpubLib"/> class with the specified <see cref="WebView"/> virtual view.
	/// </summary>
	/// <param name="virtualView"></param>
	public MauiEpubLib(WKWebView virtualView)
	{
		// Initialize your custom view here
		
	}
}

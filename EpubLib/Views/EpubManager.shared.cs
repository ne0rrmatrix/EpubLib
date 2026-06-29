#if !(ANDROID || IOS || WINDOWS || MACCATALYST || TIZEN)
global using PlatformEpubLib = System.Object;
#elif ANDROID
global using PlatformEpubLib = Android.Webkit.WebView;
#elif IOS || MACCATALYST
global using PlatformEpubLib = WebKit.WKWebView;
#elif WINDOWS
global using PlatformEpubLib = Microsoft.UI.Xaml.Controls.WebView2;
#endif
using EpubLib.Interfaces;

namespace EpubLib.Views;

/// <summary>
/// Represents a manager for the <see cref="IEpubLib"/> control, responsible for handling platform-specific functionality and managing the EPUB source.
/// </summary>
public partial class EpubManager
{

	/// <summary>
	/// Initializes a new instance of the <see cref="EpubManager"/> class with the specified <see cref="Microsoft.Maui.IMauiContext"/>, <see cref="IEpubLib"/>, and <see cref="Microsoft.Maui.Dispatching.IDispatcher"/>.
	/// </summary>
	/// <param name="context"></param>
	/// <param name="epubLib"></param>
	/// <param name="dispatcher"></param>
	public EpubManager(Microsoft.Maui.IMauiContext context, IEpubLib epubLib, Microsoft.Maui.Dispatching.IDispatcher dispatcher)
	{
		ArgumentNullException.ThrowIfNull(context);
		ArgumentNullException.ThrowIfNull(epubLib);
		ArgumentNullException.ThrowIfNull(dispatcher);
		MauiContext = context;
		EpubLib = epubLib;
		Dispatcher = dispatcher;
	}

	/// <summary>
	/// Gets the <see cref="IEpubLib"/> instance that this manager is responsible for managing.
	/// </summary>
	protected IEpubLib EpubLib { get; }

	/// <summary>
	/// Gets the <see cref="Microsoft.Maui.IMauiContext"/> instance that provides access to platform-specific services and resources.
	/// </summary>
	protected Microsoft.Maui.IMauiContext MauiContext { get; }

	/// <summary>
	/// Gets the <see cref="Microsoft.Maui.Dispatching.IDispatcher"/> instance that is used to dispatch actions to the UI thread.
	/// </summary>
	protected Microsoft.Maui.Dispatching.IDispatcher Dispatcher { get; }

#if ANDROID || IOS || MACCATALYST || WINDOWS || TIZEN
	/// <summary>
	/// The platform-specific epub reader.
	/// </summary>
	protected PlatformEpubLib? EpubReader { get; set; }
#endif

	/// <summary>
	/// Update the Epub source.
	/// </summary>
	public void UpdateSource() => PlatformUpdateSource();

	/// <summary>
	/// Invokes the platform functionality to update the media source.
	/// </summary>
	protected virtual partial void PlatformUpdateSource();
}

#if !(WINDOWS || ANDROID || IOS || MACCATALYST || TIZEN)
	partial class EpubManager
	{
		protected virtual partial void PlatformUpdateSource() { }
	}
#endif

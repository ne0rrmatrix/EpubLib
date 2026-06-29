using EpubLib.Views;
using Microsoft.Maui.Handlers;

namespace EpubLib.Handlers;

/// <summary>
/// Represents the handler for the <see cref="EpubLib"/> control, which is responsible for managing the platform-specific implementation of the EPUB reader on Windows.
/// </summary>
public partial class EpubLibHandler : ViewHandler<EpubLib, MauiEpubLib>
{
	/// <inheritdoc/>
	protected override MauiEpubLib CreatePlatformView()
	{
		EpubManager ??= new(MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null."),
								VirtualView,
								Dispatcher.GetForCurrentThread() ?? throw new InvalidOperationException($"{nameof(IDispatcher)} cannot be null"));

		var epubPlatform = EpubManager.CreatePlatformView() ?? throw new InvalidOperationException("Failed to create platform view.");
		return new(epubPlatform);
	}
}

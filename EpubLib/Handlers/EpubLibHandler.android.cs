using EpubLib.Views;
using Microsoft.Maui.Handlers;

namespace EpubLib.Handlers;

public partial class EpubLibHandler : ViewHandler<EpubLib, MauiEpubLib>
{
	protected override MauiEpubLib CreatePlatformView()
	{
		EpubManager ??= new(MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null."),
				VirtualView,
				Dispatcher.GetForCurrentThread() ?? throw new InvalidOperationException($"{nameof(Dispatcher)} cannot be null."));
		var epubPlatform = EpubManager.CreatePlatformView() ?? throw new InvalidOperationException("Failed to create platform view.");
		return new MauiEpubLib(Context, epubPlatform);
	}
}

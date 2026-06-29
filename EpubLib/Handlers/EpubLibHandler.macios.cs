using System;
using EpubLib.Views;
using Microsoft.Maui.Handlers;

namespace EpubLib.Handlers;

public partial class EpubLibHandler : ViewHandler<EpubLib, MauiEpubLib>
{
	/// <summary>
	/// Creates the platform view for the EpubLibHandler. This method initializes the EpubManager if it hasn't been created yet, and then creates the platform-specific view (MauiEpubLib) for the EpubLib control.
	/// </summary>
	/// <returns></returns>
	/// <exception cref="InvalidOperationException"></exception>
	protected override MauiEpubLib CreatePlatformView()
	{
		EpubManager ??= new(MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null."),
			VirtualView,
			Dispatcher.GetForCurrentThread() ?? throw new InvalidOperationException($"{nameof(Dispatcher)} cannot be null."));
		var epubPlatform = EpubManager.CreatePlatformView() ?? throw new InvalidOperationException("Failed to create platform view.");
		return new MauiEpubLib(epubPlatform);
	}
}

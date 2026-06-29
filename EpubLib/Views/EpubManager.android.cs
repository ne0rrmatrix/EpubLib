using EpubLib.Interfaces;

namespace EpubLib.Views;

public partial class EpubManager : Java.Lang.Object
{
	public PlatformEpubLib CreatePlatformView()
	{
		var context = MauiContext?.Context ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null.");
		EpubReader = new PlatformEpubLib(context) ?? throw new InvalidOperationException("Failed to create platform view.");
		EpubReader.Settings.JavaScriptEnabled = true;
		return EpubReader;
	}

	protected virtual async partial void PlatformUpdateSource()
	{
		if (EpubReader is null)
		{
			throw new InvalidOperationException("EpubReader is not initialized.");
		}
		if (EpubLib.Source is UriEpubSource uriEpubSource)
		{
			var uri = uriEpubSource.Uri ?? throw new InvalidOperationException("URI is not initialized.");
			MainThread.BeginInvokeOnMainThread(() =>
			{
				EpubReader.LoadUrl(uri.ToString());
			});
		}
	}
}

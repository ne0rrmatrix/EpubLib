namespace EpubLib.Views;

public partial class EpubManager
{
	/// <summary>
	/// Creates the platform-specific view for the EPUB reader. This method initializes the <see cref="PlatformEpubLib"/> instance and returns it for use in the platform-specific implementation.
	/// </summary>
	/// <returns></returns>
	public PlatformEpubLib CreatePlatformView()
	{
		EpubReader = new PlatformEpubLib() ?? throw new InvalidOperationException("Failed to create platform view.");
		return EpubReader;
	}

	protected virtual partial void PlatformUpdateSource()
	{
		if(EpubReader is null)
		{
			throw new InvalidOperationException("EpubReader is not initialized.");
		}
		if (EpubLib.Source is UriEpubSource uriEpubSource)
		{
			var uri = uriEpubSource.Uri ?? throw new InvalidOperationException("URI is not initialized.");
			EpubReader.Source = uri;
		}
	}
}

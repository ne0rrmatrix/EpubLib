namespace EpubLib.Views;

/// <summary>
/// Represents a manager for the EPUB reader control that handles platform-specific implementations and updates the source of the EPUB file.
/// </summary>
public partial class EpubManager
{
	/// <summary>
	/// Creates the platform-specific view for the EPUB reader. This method initializes the <see cref="PlatformEpubLib"/> instance and returns it for use in the platform-specific implementation.
	/// </summary>
	/// <returns></returns>
	public PlatformEpubLib CreatePlatformView()
	{
		EpubReader = new PlatformEpubLib(new Foundation.NSCoder()) ?? throw new InvalidOperationException("Failed to create platform view.");
		return EpubReader;
	}

	protected virtual async partial void PlatformUpdateSource()
	{
	}
}

using Microsoft.Maui.Handlers;

namespace EpubLib.Handlers;

public partial class EpubLibHandler : ViewHandler<EpubLib, PlatformEpubLib>
{
	/// <summary>
	/// Creates the platform view for the EpubLibHandler. This method is not implemented for this platform and will throw a NotImplementedException if called.
	/// </summary>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	protected override PlatformEpubLib CreatePlatformView() => throw new NotImplementedException("PlatformEpubLib is not implemented for this platform.");

	// Ignoring XML comments for this implementation since it's not used.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static void MapSource(object handler, EpubLib EpubLib) => throw new NotImplementedException("MapSource is not implemented for this platform.");
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
}

using EpubLib.Handlers;

namespace EpubLib;

/// <summary>
/// Provides extension methods for configuring the EpubLib library in a .NET MAUI application.
/// </summary>
public static class AppBuilderExtensions
{
	/// <summary>
	/// Configures the .NET MAUI application to use the EpubLib library by adding the necessary handlers for the EpubLib control.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static MauiAppBuilder UseEpubLib(this MauiAppBuilder builder)
	{
		builder.ConfigureMauiHandlers(h =>
		{
			h.AddHandler<EpubLib, EpubLibHandler>();
		});
		return builder;
	}
}

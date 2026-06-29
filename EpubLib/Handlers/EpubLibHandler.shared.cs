using EpubLib.Interfaces;
using EpubLib.Views;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace EpubLib.Handlers;


/// <summary>
/// Represents the handler for the <see cref="EpubLib"/> control, which is responsible for managing the platform-specific implementation of the EPUB reader.
/// </summary>
public partial class EpubLibHandler
{
	/// <summary>
	/// Gets the property mapper for the <see cref="EpubLibHandler"/>, which maps properties from the cross-platform <see cref="EpubLib"/> control to the platform-specific implementation.
	/// </summary>
	public static IPropertyMapper<EpubLib, EpubLibHandler> PropertyMapper = new PropertyMapper<EpubLib, EpubLibHandler>(ViewHandler.ViewMapper)
	{
		[nameof(IEpubLib.Source)] = MapSource,
	};

	/// <summary>
	/// Gets the command mapper for the <see cref="EpubLibHandler"/>, which maps commands from the cross-platform <see cref="EpubLib"/> control to the platform-specific implementation.
	/// </summary>
	public static CommandMapper<EpubLib, EpubLibHandler> CommandMapper = new(ViewCommandMapper)
	{
	};

	/// <summary>
	/// Initializes a new instance of the <see cref="EpubLibHandler"/> class with the default property and command mappers.
	/// </summary>
	public EpubLibHandler() : base(PropertyMapper, CommandMapper)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="EpubLibHandler"/> class with the specified property and command mappers.
	/// </summary>
	/// <param name="propertyMapper"></param>
	/// <param name="commandMapper"></param>
	public EpubLibHandler(IPropertyMapper? propertyMapper, CommandMapper? commandMapper) : base(propertyMapper ?? PropertyMapper, commandMapper ?? CommandMapper)
	{
	}

#if ANDROID || IOS || MACCATALYST || WINDOWS || TIZEN
	/// <summary>
	/// The <see cref="Views.EpubManager"/> that is managing the <see cref="IEpubLib"/> instance.
	/// </summary>
	
	protected EpubManager? EpubManager { get; set; }

	/// <summary>
	/// Maps the <see cref="IEpubLib.Source"/> property from the cross-platform <see cref="EpubLib"/> control to the platform-specific implementation.
	/// </summary>
	/// <param name="handler"></param>
	/// <param name="epubLib"></param>
	public static void MapSource(EpubLibHandler handler, EpubLib epubLib)
	{
		handler.EpubManager?.UpdateSource();
	}
#endif
}

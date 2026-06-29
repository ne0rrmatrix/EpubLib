using EpubLib.Views;
using Microsoft.Maui;

namespace EpubLib.Interfaces;

/// <summary>
/// Defines the interface for an EPUB reader control that can be used in .NET MAUI applications.
/// </summary>
public interface IEpubLib : IView
{
	/// <summary>
	/// Gets or sets the source of the EPUB file to be displayed in the EPUB reader.
	/// </summary>
	EpubSource? Source { get; set; }
}

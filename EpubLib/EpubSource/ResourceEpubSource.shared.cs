using System.ComponentModel;
using EpubLib.Converters;
using Microsoft.Maui.Controls;

namespace EpubLib.Views;

/// <summary>
/// Represents a media source that loads media from an embedded resource file.
/// </summary>
[TypeConverter(typeof(FileEpubSourceConverter))]
public sealed partial class ResourceEpubSource : EpubSource
{
	/// <summary>
	/// Bindable Property for the <see cref="Path"/> property.
	/// </summary>
	public static readonly BindableProperty PathProperty
		= BindableProperty.Create(nameof(Path), typeof(string), typeof(ResourceEpubSource), propertyChanged: OnResourceEpubSourceEpubSourceChanged);

	/// <summary>
	/// Gets or sets the full path to the resource file to use as a media source.
	/// This is a bindable property.
	/// </summary>
	/// <remarks>
	/// Path is relative to the application's resources folder.
	/// It can only be just a filename if the resource file is in the root of the resources folder.
	/// </remarks>
	public string? Path
	{
		get => (string?)GetValue(PathProperty);
		set => SetValue(PathProperty, value);
	}

	/// <summary>
	/// An implicit operator to convert a string value into a <see cref="ResourceEpubSource"/>.
	/// </summary>
	/// <param name="path">Full path to the resource file, relative to the application's resources folder.</param>
	public static implicit operator ResourceEpubSource(string path) => (ResourceEpubSource)FromFile(path);

	/// <summary>
	/// An implicit operator to convert a <see cref="ResourceEpubSource"/> into a string value.
	/// </summary>
	/// <param name="resourceMediaSource">A <see cref="ResourceEpubSource"/> instance to convert to a string value.</param>
	public static implicit operator string?(ResourceEpubSource? resourceMediaSource) => resourceMediaSource?.Path;

	/// <inheritdoc/>
	public override string ToString() => $"Resource: {Path}";

	static void OnResourceEpubSourceEpubSourceChanged(BindableObject bindable, object oldValue, object newValue) =>
		((ResourceEpubSource)bindable).OnSourceChanged();
}
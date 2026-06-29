using System.ComponentModel;
using EpubLib.Converters;
using Microsoft.Maui.Controls;

namespace EpubLib.Views;

/// <summary>
/// Represents a media source that loads media from a local file.
/// </summary>
[TypeConverter(typeof(FileEpubSourceConverter))]
public sealed partial class FileEpubSource : EpubSource
{
	/// <summary>
	/// Bindable Property for the <see cref="Path"/> property.
	/// </summary>
	public static readonly BindableProperty PathProperty
		= BindableProperty.Create(nameof(Path), typeof(string), typeof(FileEpubSource), propertyChanged: OnFileEpubSourceChanged);

	/// <summary>
	/// Gets or sets the full path to the local file to use as a media source.
	/// This is a bindable property.
	/// </summary>
	public string? Path
	{
		get => (string?)GetValue(PathProperty);
		set => SetValue(PathProperty, value);
	}

	/// <summary>
	/// An implicit operator to convert a string value into a <see cref="FileEpubSource"/>.
	/// </summary>
	/// <param name="path">Full path to the local file. Can be a relative or absolute path.</param>
	public static implicit operator FileEpubSource(string path) => (FileEpubSource)FromFile(path);

	/// <summary>
	/// An implicit operator to convert a <see cref="FileEpubSource"/> into a string value.
	/// </summary>
	/// <param name="fileEpubSource">A <see cref="FileEpubSource"/> instance to convert to a string value.</param>
	public static implicit operator string?(FileEpubSource? fileEpubSource) => fileEpubSource?.Path;


	/// <inheritdoc/>
	public override string ToString() => $"File: {Path}";

	static void OnFileEpubSourceChanged(BindableObject bindable, object oldValue, object newValue) =>
		((FileEpubSource)bindable).OnSourceChanged();
}
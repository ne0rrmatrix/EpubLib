using System.ComponentModel;
using System.Globalization;
using EpubLib.Views;

namespace EpubLib.Converters;

/// <summary>
/// Represents a <see cref="TypeConverter"/> specific to converting a string value to a <see cref="EpubSource"/>.
/// </summary>
public sealed class EpubSourceConverter : TypeConverter
{
	const string embeddedResourcePrefix = "embed://";
	const string fileSystemPrefix = "filesystem://";

	/// <inheritdoc/>
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
			=> sourceType == typeof(string);

	/// <inheritdoc/>
	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
		=> destinationType == typeof(string);

	/// <inheritdoc/>
	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
	{
		var valueAsString = value?.ToString() ?? string.Empty;

		if (string.IsNullOrWhiteSpace(valueAsString))
		{
			return null;
		}

		var valueAsStringLowercase = valueAsString.ToLowerInvariant();

		if (valueAsStringLowercase.StartsWith(embeddedResourcePrefix))
		{
			return EpubSource.FromResource(
				valueAsString[embeddedResourcePrefix.Length..]);
		}

		if (valueAsStringLowercase.StartsWith(fileSystemPrefix))
		{
			return EpubSource.FromFile(valueAsString[fileSystemPrefix.Length..]);
		}

		return Uri.TryCreate(valueAsString, UriKind.Absolute, out var uri) && uri.Scheme != "file"
			? EpubSource.FromUri(uri)
			: EpubSource.FromFile(valueAsString);
	}

	/// <inheritdoc/>
	public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) => value switch
	{
		UriEpubSource uriEpubSource => uriEpubSource.ToString(),
		FileEpubSource fileEpubSource => fileEpubSource.ToString(),
		ResourceEpubSource resourceEpubSource => resourceEpubSource.ToString(),
		StreamEpubSource streamEpubSource => streamEpubSource.ToString(),
		EpubSource => string.Empty,
		_ => throw new ArgumentException($"Invalid Media Source", nameof(value))
	};
}
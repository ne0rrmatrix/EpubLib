using System.ComponentModel;
using System.Globalization;
using EpubLib.Views;

namespace EpubLib.Converters;

/// <summary>
/// A <see cref="TypeConverter"/> specific to converting a string value to a <see cref="FileEpubSource"/>.
/// </summary>
[TypeConverter(typeof(FileEpubSource))]
public sealed class FileEpubSourceConverter : TypeConverter
{
	/// <inheritdoc/>
	/// <exception cref="InvalidOperationException">Thrown when <paramref name="value"/> is <see langword="null"/> or empty.</exception>
	public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		var filePath = value.ToString() ?? string.Empty;

		return string.IsNullOrWhiteSpace(filePath)
			? (FileEpubSource)EpubSource.FromFile(filePath)
			: throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(FileEpubSource)}");
	}
}
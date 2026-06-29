using System.ComponentModel;
using EpubLib.Converters;

namespace EpubLib.Views;

/// <summary>
/// Represents a media source that can be used to load media from various sources, such as files, streams, or URIs.
/// </summary>
[TypeConverter(typeof(EpubSourceConverter))]
public abstract class EpubSource : Element
{
	static readonly bool isAndroid = OperatingSystem.IsAndroid();
	readonly WeakEventManager weakEventManager = new();

	internal event EventHandler SourceChanged
	{
		add => weakEventManager.AddEventHandler(value);
		remove => weakEventManager.RemoveEventHandler(value);
	}

	/// <summary>
	/// An implicit operator to convert a string value into a <see cref="EpubSource"/>.
	/// </summary>
	/// <param name="source">Full path to a local file (starting with <c>file://</c>) or an absolute URI.</param>
	public static implicit operator EpubSource(string source) =>
		Uri.TryCreate(source, UriKind.Absolute, out var uri) && uri.Scheme != Uri.UriSchemeFile
			? FromUri(uri)
			: FromFile(source);

	/// <summary>
	/// An implicit operator to convert a <see cref="Uri"/> object into a <see cref="UriEpubSource"/>.
	/// </summary>
	/// <param name="uri">Absolute URI to load.</param>
	public static implicit operator EpubSource(Uri uri) => FromUri(uri);

	/// <summary>
	/// Creates a <see cref="ResourceEpubSource"/> from an absolute URI.
	/// </summary>
	/// <param name="path">Full path to the resource file, relative to the application's resources folder.</param>
	/// <returns>A <see cref="ResourceEpubSource"/> instance.</returns>
	public static EpubSource FromResource(string path) => new ResourceEpubSource { Path = isAndroid ? $"Assets/{path}" : path };

	/// <summary>
	/// Creates a <see cref="UriEpubSource"/> from a string that contains an absolute URI.
	/// </summary>
	/// <param name="uri">String representation or an absolute URI to load.</param>
	/// <returns>A <see cref="UriEpubSource"/> instance.</returns>
	/// <exception cref="ArgumentException">Thrown if <paramref name="uri"/> is not an absolute URI.</exception>
	public static EpubSource FromUri(string uri) => FromUri(new Uri(uri));

	/// <summary>
	/// Creates a <see cref="FileEpubSource"/> from a local path.
	/// </summary>
	/// <param name="path">Full path to the file to load.</param>
	/// <returns>A <see cref="FileEpubSource"/> instance.</returns>
	public static EpubSource FromFile(string path) => new FileEpubSource { Path = path };

	/// <summary>
	/// Creates a <see cref="StreamEpubSource"/> from a <see cref="Stream"/>.
	/// </summary>
	/// <param name="stream">The stream to use as a media source.</param>
	/// <returns>A <see cref="StreamEpubSource"/> instance.</returns>
	public static StreamEpubSource FromStream(Stream stream) => new StreamEpubSource { Stream = stream };

	/// <summary>
	/// Creates a <see cref="UriEpubSource"/> from an absolute URI.
	/// </summary>
	/// <param name="uri">Absolute URI to load.</param>
	/// <returns>A <see cref="UriEpubSource"/> instance.</returns>
	/// <exception cref="ArgumentException">Thrown if <paramref name="uri"/> is not an absolute URI.</exception>
	public static EpubSource FromUri(Uri uri)
	{
		ArgumentNullException.ThrowIfNull(uri);

		return uri.IsAbsoluteUri
			? new UriEpubSource { Uri = uri }
			: throw new ArgumentException("Uri must be absolute", nameof(uri));
	}

	/// <summary>
	/// Creates a <see cref="UriEpubSource"/> from an absolute URI with custom HTTP headers.
	/// </summary>
	/// <param name="uri">Absolute URI to load.</param>
	/// <param name="httpHeaders">HTTP headers to include in the request (e.g. Authorization).</param>
	/// <returns>A <see cref="UriEpubSource"/> instance.</returns>
	/// <exception cref="ArgumentException">Thrown if <paramref name="uri"/> is not an absolute URI.</exception>
	public static EpubSource FromUri(Uri uri, IDictionary<string, string> httpHeaders)
	{
		ArgumentNullException.ThrowIfNull(uri);
		ArgumentNullException.ThrowIfNull(httpHeaders);

		if (!uri.IsAbsoluteUri)
		{
			throw new ArgumentException("Uri must be absolute", nameof(uri));
		}

		var uriMediaSource = new UriEpubSource { Uri = uri };
		foreach (var httpHeader in httpHeaders)
		{
			uriMediaSource.HttpHeaders.Add(httpHeader.Key, httpHeader.Value);
		}

		return uriMediaSource;
	}

	/// <summary>
	/// Triggers the <see cref="SourceChanged"/> event.
	/// </summary>
	protected void OnSourceChanged() => weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(SourceChanged));
}
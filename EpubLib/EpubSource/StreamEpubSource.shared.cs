namespace EpubLib.Views;

/// <summary>
/// Represents a media source that loads media from a <see cref="System.IO.Stream"/>.
/// </summary>
public sealed partial class StreamEpubSource : EpubSource
{
	/// <summary>
	/// Backing store for the <see cref="Stream"/> property.
	/// </summary>
	public static readonly BindableProperty StreamProperty
		= BindableProperty.Create(nameof(Stream), typeof(Stream), typeof(StreamEpubSource), propertyChanged: OnStreamEpubSourceChanged);

	/// <summary>
	/// Gets or sets the stream to use as a media source.
	/// This is a bindable property.
	/// </summary>
	public Stream? Stream
	{
		get => (Stream?)GetValue(StreamProperty);
		set => SetValue(StreamProperty, value);
	}

	/// <summary>
	/// An implicit operator to convert a <see cref="System.IO.Stream"/> value into a <see cref="StreamEpubSource"/>.
	/// </summary>
	/// <param name="stream">The stream to use as a media source.</param>
	public static implicit operator StreamEpubSource?(Stream? stream) => stream is not null ? FromStream(stream) : null;

	/// <summary>
	/// An implicit operator to convert a <see cref="StreamEpubSource"/> into a <see cref="System.IO.Stream"/> value.
	/// </summary>
	/// <param name="streamEpubSource">A <see cref="StreamEpubSource"/> instance to convert to a <see cref="System.IO.Stream"/> value.</param>
	public static implicit operator Stream?(StreamEpubSource? streamEpubSource) => streamEpubSource?.Stream;


	/// <inheritdoc/>
	public override string ToString() => $"Stream: {Stream?.GetType().Name ?? "null"}";

	static void OnStreamEpubSourceChanged(BindableObject bindable, object oldValue, object newValue) =>
		((StreamEpubSource)bindable).OnSourceChanged();
}
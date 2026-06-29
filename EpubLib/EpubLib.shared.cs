using EpubLib.Interfaces;
using EpubLib.Converters;
using EpubLib.Views;
using System.ComponentModel;

namespace EpubLib;

/// <summary>
/// Represents a cross-platform EPUB reader control that can be used in .NET MAUI applications.
/// </summary>
public partial class EpubLib : View, IEpubLib
{
	/// <summary>
	/// Bindable property for the <see cref="Source"/> property.
	/// </summary>
	public static readonly BindableProperty SourceProperty = 
		BindableProperty.Create(nameof(Source), typeof(EpubSource), typeof(EpubLib), propertyChanging: OnSourcePropertyChanging, propertyChanged: OnSourcePropertyChanged);

	/// <summary>
	/// Gets or sets the source of the EPUB content to be displayed in the control.
	/// </summary>
	[TypeConverter(typeof(EpubSourceConverter))]
	public EpubSource? Source
	{
		get => (EpubSource?)GetValue(SourceProperty);
		set => SetValue(SourceProperty, value);
	}

	static void OnSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var epubLib = (EpubLib)bindable;
		var source = (EpubSource?)newValue;

		if (source is not null)
		{
			source.SourceChanged += epubLib.OnSourceChanged;
			SetInheritedBindingContext(source, epubLib.BindingContext);
		}

		epubLib.InvalidateMeasure();
	}

	static void OnSourcePropertyChanging(BindableObject bindable, object oldValue, object newValue)
	{
		var epubLib = (EpubLib)bindable;
		var oldEpubSource = (EpubSource?)oldValue;

		oldEpubSource?.SourceChanged -= epubLib.OnSourceChanged;
	}

	void OnSourceChanged(object? sender, EventArgs eventArgs)
	{
		OnPropertyChanged(SourceProperty.PropertyName);
		InvalidateMeasure();
	}
}

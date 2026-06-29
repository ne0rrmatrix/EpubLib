using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.CoordinatorLayout.Widget;
using WebView = Android.Webkit.WebView;

namespace EpubLib.Views;

public partial class MauiEpubLib : CoordinatorLayout
{
	readonly RelativeLayout relativeLayout;

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
#pragma warning disable IDE0060 // Remove unused parameter
	public MauiEpubLib(Context? context) : base(context)
	{
		// Initialize your custom view here
	}

	public MauiEpubLib(Context? context, Android.Util.IAttributeSet? attrs) : base(context, attrs)
	{
		// Initialize your custom view here with attributes
	}

	public MauiEpubLib(Context? context, Android.Util.IAttributeSet? attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
	{
		// Initialize your custom view here with attributes and style
	}

	public MauiEpubLib(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
	{

	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
#pragma warning restore IDE0060 // Remove unused parameter

	public MauiEpubLib(Context context, WebView epubLib) : base(context)
	{
		var layout = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
		relativeLayout = new RelativeLayout(Platform.AppContext)
		{
			LayoutParameters = layout,
		};
		relativeLayout.AddView(epubLib);
		AddView(relativeLayout);
	}
}

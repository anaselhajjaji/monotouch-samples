// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ViewPager
{
	[Register ("PageViewController")]
	partial class PageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Label { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Label != null) {
				Label.Dispose ();
				Label = null;
			}
		}
	}
}

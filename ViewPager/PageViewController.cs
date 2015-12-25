using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ViewPager
{
    partial class PageViewController : UIViewController
    {
        public int Index { get; set; }

        public PageViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Label.Text += Index.ToString();
        }
    }
}

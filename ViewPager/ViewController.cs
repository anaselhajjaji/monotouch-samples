using System;

using UIKit;

namespace ViewPager
{
    public partial class ViewController : UIViewController
    {
        private UIPageViewController pageController;
        private UIViewController[] viewControllers;

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializePages();

            pageController = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal);

            pageController.DataSource = new PagerDataSource(viewControllers);

            pageController.View.Frame = this.View.Bounds;

            UIViewController initialViewController = viewControllers[0];

            pageController.SetViewControllers(new UIViewController[1] { initialViewController },
                UIPageViewControllerNavigationDirection.Forward, false, null);

            this.AddChildViewController(pageController);
            this.View.AddSubview(pageController.View);
            pageController.DidMoveToParentViewController(this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void InitializePages()
        {
            viewControllers = new UIViewController[5];

            for (int i = 0; i < 5; i++)
            {
                viewControllers[i] = Storyboard.InstantiateViewController("PageViewController");
                (viewControllers[i] as PageViewController).Index = i;
            }
        }

        class PagerDataSource : UIPageViewControllerDataSource
        {
            private UIViewController[] viewControllers;

            public PagerDataSource(UIViewController[] controllers)
            {
                this.viewControllers = controllers;
            }

            #region implemented abstract members of UIPageViewControllerDataSource

            public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                int index = (referenceViewController as PageViewController).Index;

                index++;

                if (index == viewControllers.Length)
                {
                    return null;
                }

                return viewControllers[index];

            }

            public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                int index = (referenceViewController as PageViewController).Index;

                if (index == 0)
                {
                    return null;
                }

                // Decrease the index by 1 to return
                index--;

                return viewControllers[index];
            }

            public override nint GetPresentationCount(UIPageViewController pageViewController)
            {
                return viewControllers.Length;
            }

            public override nint GetPresentationIndex(UIPageViewController pageViewController)
            {
                return 0;
            }

            #endregion
        }
    }
}


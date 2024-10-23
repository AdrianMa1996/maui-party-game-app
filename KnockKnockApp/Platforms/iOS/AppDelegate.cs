using Foundation;
using UIKit;

namespace KnockKnockApp
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        [Export("application:supportedInterfaceOrientationsForWindow:")]
        public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            if (forWindow.WindowScene != null && forWindow.WindowScene.Title == "PerformPortraitOrientation")
            {
                return UIInterfaceOrientationMask.Portrait;
            }
            else if(forWindow.WindowScene != null && forWindow.WindowScene.Title == "PerformLandscapeOrientation")
            {
                return UIInterfaceOrientationMask.Landscape;
            }
            else
            {
                return application.SupportedInterfaceOrientationsForWindow(forWindow);
            }
        }
    }
}

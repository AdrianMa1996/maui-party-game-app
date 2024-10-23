using Foundation;
using UIKit;

namespace KnockKnockApp.Services
{
    public partial class DeviceOrientationService
    {
        private static readonly IReadOnlyDictionary<DisplayOrientation, UIInterfaceOrientation> _iosDisplayOrientationMap =
            new Dictionary<DisplayOrientation, UIInterfaceOrientation>
            {
                [DisplayOrientation.Landscape] = UIInterfaceOrientation.LandscapeLeft, // Es gibt irgenwie keins mit Sensor
                [DisplayOrientation.Portrait] = UIInterfaceOrientation.Portrait, // Es gibt irgenwie keins mit Sensor
            };

        public partial void SetDeviceOrientation(DisplayOrientation displayOrientation)
        {
            if (_iosDisplayOrientationMap.TryGetValue(displayOrientation, out var iosOrientation))
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(16, 0))
                {
                    var scene = (UIApplication.SharedApplication.ConnectedScenes.ToArray()[0] as UIWindowScene);
                    if (scene != null)
                    {
                        UIInterfaceOrientationMask NewOrientation;
                        scene.Title = "";
                        if (iosOrientation == UIInterfaceOrientation.Portrait)
                        {
                            NewOrientation = UIInterfaceOrientationMask.Portrait;
                            scene.Title = "PerformPortraitOrientation";
                        }
                        else
                        {
                            NewOrientation = UIInterfaceOrientationMask.LandscapeLeft;
                            scene.Title = "PerformLandscapeOrientation";
                        }

                        scene.RequestGeometryUpdate(
                            new UIWindowSceneGeometryPreferencesIOS(NewOrientation), error => { System.Diagnostics.Debug.WriteLine(error.ToString()); });
                    }
                }
                else
                {
                    UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)iosOrientation), new NSString("orientation"));
                }
            }
        }
    }
}

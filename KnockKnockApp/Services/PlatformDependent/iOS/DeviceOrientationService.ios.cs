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
                UIApplication.SharedApplication.SetStatusBarOrientation(iosOrientation, true);
        }
    }
}

using Android.Content.PM;

namespace KnockKnockApp.Services
{
    public partial class DeviceOrientationService
    {
        private static readonly IReadOnlyDictionary<DisplayOrientation, ScreenOrientation> _androidDisplayOrientationMap =
            new Dictionary<DisplayOrientation, ScreenOrientation>
            {
                [DisplayOrientation.Landscape] = ScreenOrientation.SensorLandscape,
                [DisplayOrientation.Portrait] = ScreenOrientation.SensorPortrait,
            };

        public partial void SetDeviceOrientation(DisplayOrientation displayOrientation)
        {
            var currentActivity = ActivityStateManager.Default.GetCurrentActivity();
            if (currentActivity is not null)
            {
                if (_androidDisplayOrientationMap.TryGetValue(displayOrientation, out ScreenOrientation screenOrientation))
                    currentActivity.RequestedOrientation = screenOrientation;
            }
        }
    }
}

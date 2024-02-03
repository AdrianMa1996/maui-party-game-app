using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Services
{
    public partial class DeviceOrientationService : IDeviceOrientationService
    {
        public partial void SetDeviceOrientation(DisplayOrientation displayOrientation);
    }
}

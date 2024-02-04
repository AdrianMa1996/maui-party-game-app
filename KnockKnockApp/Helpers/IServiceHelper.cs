using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Helpers
{
    public interface IServiceHelper
    {
        TService GetService<TService>();
    }
}

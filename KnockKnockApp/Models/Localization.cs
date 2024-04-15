using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Models
{
    public class Localization
    {
        public Localization(string name, CultureInfo culture)
        {
            Name = name;
            Culture = culture;
        }

        public string Name { get; set; }
        public CultureInfo Culture { get; set; }
    }
}

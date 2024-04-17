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
        public Localization(string name, CultureInfo culture, string flagImage)
        {
            Name = name;
            Culture = culture;
            FlagImage = flagImage;
        }

        public string Name { get; set; }
        public CultureInfo Culture { get; set; }
        public string FlagImage { get; set; }
    }
}

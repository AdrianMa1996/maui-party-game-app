using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Services
{
    public interface ICardTextPlaceholderService
    {
        public void SetupAndShuffleLists();
        public string ResolveTextPlaceholders(string text);
    }
}

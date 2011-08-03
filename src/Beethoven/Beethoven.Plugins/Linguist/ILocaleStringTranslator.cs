using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beethoven.Plugins.Linguist
{
    public interface ILocaleStringTranslator
    {
        string TranslateLocaleString(string localeStringID);
    }
}

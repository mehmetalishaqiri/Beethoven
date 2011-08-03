using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Beethoven.Plugins.Linguist
{
    
    public class Translator:ILocaleStringTranslator
    {
        private Language CurrentLanguage;

        private string languageCode;
        
        public Translator(string languageCode)
        {
            string code = String.Empty;
            List<string> supportedLanguages = Languages.SupportedLanguages.Select(c => c.Code).ToList();

            code = supportedLanguages.Contains(languageCode) ? languageCode : Languages.DefaultLanguage.Code;

            CurrentLanguage = Languages.GetLanguage(code);
        }


        #region ILocaleStringTranslator Members

        public string TranslateLocaleString(string localeStringID)
        {          
            
            string newValue = String.Empty;
            XDocument xmlDoc = XDocument.Load(CurrentLanguage.XmlFile);
            var query = xmlDoc.Element("localization").Elements("resource");

            foreach (var item in query)
            {
                if (item.Attribute("id").Value == localeStringID)
                    newValue = item.Element("value").Value; 
            }
            return newValue;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Options
{
    abstract  class Language
    {
        public string language;
        public Language(string lang)
        {
            this.language = lang;
        }
        public abstract void ChangeLanguage();
    }
}

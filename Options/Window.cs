using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Options
{
    public class Window
    {
        public bool FontSettings { get; set; }
        public bool SizesSettings { get; set; }
        public bool ThemeSettings { get; set; }
        public Window(bool font,bool size,bool theme)
        {
            FontSettings = font;
            SizesSettings = size;
            ThemeSettings = theme;
        }
    }
}

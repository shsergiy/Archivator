using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Options.Decor
{
    class Theme : WindowHandler
    {
        //todo
        public void AutoTheme()
        {

        }
        public override void Handler(Window window)
        {
            if (window.ThemeSettings == true)
            {
                AutoTheme();
                if (Secsesor != null)
                    Secsesor.Handler(window);
            }
            else if (Secsesor != null)
            {
                Secsesor.Handler(window);
            }
        }
    }
}

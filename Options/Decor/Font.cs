﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Options.Decor
{
    class Font : WindowHandler
    {
        //todo
        public void AutoFont() { }
        public override void Handler(Window window)
        {
            if (window.FontSettings == true)
            {
                AutoFont();
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

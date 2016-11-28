using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Options.Decor
{
    class Sizes : WindowHandler
    {
        //todo
        public void AutoSize() { }
        public override void Handler(Window window)
        {
            if (window.SizesSettings == true)
            {
                AutoSize();
                if(Secsesor!=null)
                   Secsesor.Handler(window);
            }
            else if (Secsesor != null)
            {
                Secsesor.Handler(window);
            }
        }
    }
}

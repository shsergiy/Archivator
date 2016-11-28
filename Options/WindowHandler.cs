using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Options
{
   abstract class WindowHandler
    {
        public WindowHandler Secsesor { get; set; }
        public abstract void Handler(Window window);
    }
}

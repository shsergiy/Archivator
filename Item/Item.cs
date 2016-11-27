using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Item
{
    abstract class Item
    {
        public abstract void CreateItem(string path);
        public abstract void DeleteItem(string path);
             
    }
}

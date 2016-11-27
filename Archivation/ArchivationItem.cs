using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Archivation
{//call all functional from IComand 
    public class ArchivationItem
    {
        public ArchivationItem(IComand comand)
        {
            Comand = comand;
        }
        public IComand Comand { private get; set; }
        public void Archivate(List<string> list,string type)
        {
            if (type == "Folder")
                {
                    Comand.ArchivateFolder(list[0]);
                }
            else if (type == "File")
                {
                    Comand.ArchivateFile(list);
                }
        }
        public void Dearchivate(string path)
        {
            Comand.Dearchivate(path);
        }
        public void CheckSum(string path)
        {
            Comand.CheckSum(path);
        }
        public void Check(string path)
        {
            Comand.TestProblems(path);
        }
            
            
    }
}

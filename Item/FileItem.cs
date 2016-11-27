using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Archivator_STP_Project_.Item
{
    class FileItem : Item
    {
        public override void CreateItem(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    throw new Exception("File with this name exist");
                }
                File.Create(path);
            }
            catch(Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }

        public override void DeleteItem(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                {
                    throw new Exception("File with this name is not exist");
                }
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }
    }
}

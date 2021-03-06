﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Archivator_STP_Project_.Item
{
    class Folder : Item
    {
        public override void CreateItem(string path)
        {
          try
            {
                if (Directory.Exists(path))
                {
                    throw new Exception("That path exists already");
                }
                DirectoryInfo Info = Directory.CreateDirectory(path);
                MessageBox.Show("Directory on this path " + path + " successfully created");
            }
            catch(Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }

        public override void DeleteItem(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
                else
                {
                    throw new Exception("That path is not exists");
                }
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivator_STP_Project_.Archivation
{
    class Comand_7Z : IComand
    {
        public void ArchivateFile(List<string> Paths)
        {
            throw new NotImplementedException();
        }

        public void ArchivateFile(string path)
        {
            throw new NotImplementedException();
        }

        public void ArchivateFolder(string Path)
        {
            throw new NotImplementedException();
        }
       //todo Metadata
        public void ChangeMetaData(string Path)
        {
            throw new NotImplementedException();
        }

        public void CheckSum(string Path)
        {
            try
            {
                string result;
                using (FileStream fs = System.IO.File.OpenRead(Path))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, (int)fs.Length);
                    byte[] checkSum = md5.ComputeHash(fileData);
                    result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                }
                MessageBox.Show(result);
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }

      
        public void Dearchivate(string Path)
        {
            throw new NotImplementedException();
        }
        //todo
        public void Fragmentation(string Path)
        {
            throw new NotImplementedException();
        }
        //todo
        public void TestProblems(string Path)
        {
            throw new NotImplementedException();
        }
    }
}

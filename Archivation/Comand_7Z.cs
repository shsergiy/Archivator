using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip.SDK;
namespace Archivator_STP_Project_.Archivation
{
    class Comand_7Z : IComand
    {
        //todo
        public void ArchivateFile(List<string> Paths)
        {
            try
            {
                string outFile = "";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Saving archive";
                saveFile.FileName = "Archive (" + DateTime.Now.ToShortDateString() + ")";
                saveFile.Filter = "Файл ZIP|*.zip";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    outFile = saveFile.FileName;
                }
                else throw new Exception("Path warning");
                SevenZip.SDK.Compress.LZMA.Encoder coder = new SevenZip.SDK.Compress.LZMA.Encoder();
                FileStream input = new FileStream(Paths[1], FileMode.Open);
                FileStream output = new FileStream(outFile, FileMode.Create);
                coder.WriteCoderProperties(output);
                output.Write(BitConverter.GetBytes(input.Length), 0, 8);
                coder.Code(input, output, input.Length, -1, null);
                output.Flush();
                output.Close();
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }
     
        //NO
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

        //todo
        public void Dearchivate(string Path)
        {
            try
            {
                string outFile = "";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Saving archive";
                saveFile.FileName = "Archive (" + DateTime.Now.ToShortDateString() + ")";
                saveFile.Filter = "Файл ZIP|*.zip";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    outFile = saveFile.FileName;
                }
                SevenZip.SDK.Compress.LZMA.Decoder coder = new SevenZip.SDK.Compress.LZMA.Decoder();
                FileStream input = new FileStream(Path, FileMode.Open);
                FileStream output = new FileStream(outFile, FileMode.Create);

  
                byte[] properties = new byte[5];
                input.Read(properties, 0, 5);

                byte[] fileLengthBytes = new byte[8];
                input.Read(fileLengthBytes, 0, 8);
                long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                coder.SetDecoderProperties(properties);
                coder.Code(input, output, input.Length, fileLength, null);
                output.Flush();
                output.Close();
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }
        //todo
        public void Fragmentation(string Path)
        {
            throw new NotImplementedException();
        }
        //NO
        public void TestProblems(string Path)
        {
            throw new NotImplementedException();
        }
    }
}

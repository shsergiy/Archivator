using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Security.Cryptography;

namespace Archivator_STP_Project_.Archivation
{
    public class Comand_Zip :IComand
    {
        ZipFile zip;
        
       
        public void ArchivateFile(List<string> Paths)
        {
            try
            {
                string Path = "";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Saving archive";
                saveFile.FileName = "Archive (" + DateTime.Now.ToShortDateString() + ")";
                saveFile.Filter = "Файл ZIP|*.zip";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    Path = saveFile.FileName;
                }
                else throw new Exception("Path warning");
                using ( zip = new ZipFile(Path, Encoding.UTF8))
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.TempFileFolder = System.IO.Path.GetTempPath();
                    foreach (string file in Paths)
                    {
                        zip.AddFile(file, "\\");
                    }
                    zip.Save();
                    zip = null;
                }
                MessageBox.Show("Successfully saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex) { MessageBox.Show("Unsuccessfully saved !, try again! " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        //change archivationFoder
        public void ArchivateFolder(string Path)
        {
            try
            {
                string pathname = "";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Saving archive";
                saveFile.FileName = "Archive (" + DateTime.Now.ToShortDateString() + ")";
                saveFile.Filter = "Файл ZIP|*.zip";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    pathname = saveFile.FileName;
                }
                else throw new Exception("Path warning");
                using (ZipFile zip = new ZipFile(pathname,Encoding.UTF8))
                {
                    zip.AddDirectory(Path);
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.Save(string.Format("New.zip"));
                }
            }
            catch(Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }
        //todo
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
            try
            {
                string path = "";

                FolderBrowserDialog saveDialog = new FolderBrowserDialog();
                saveDialog.Description = "Выберите папку для разархивации";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveDialog.SelectedPath;
                }

                else throw new Exception("Не выбрано место для разархивации архива!");
                using (zip = new ZipFile(Path, Encoding.UTF8))
                {
                    zip.TempFileFolder = System.IO.Path.GetTempPath();
                    zip.ExtractAll(path, ExtractExistingFileAction.OverwriteSilently);
                    zip = null;
                }
                MessageBox.Show("Данные успешно извлечены", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при попытки сохранения архива, попробуйте еще раз! " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        //todo
        public void Fragmentation(string Path)
        {
            throw new NotImplementedException();
        }

        public void TestProblems(string Path)
        {
            try
            {
                ZipFile.CheckZip(Path);
            }
            catch (Exception ex) { MessageBox.Show("Archive is bad"); }
        }

  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Checksums;
using Ionic.Zip;
using System.Security.Cryptography;
namespace Archivator_STP_Project_.Archivation
{
    public class Comand_GZ : IComand
    {
      

        public void ArchivateFile(List<string> Paths)
        {
            try
            {
                string savepath = "";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Save archive";
                saveFile.FileName = "New Archive";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    savepath = saveFile.FileName;
                }
                String tarArchiveName = @"" + savepath + ".tar.gz";
                using (var outStream = File.Create(tarArchiveName))
                using (var gzoStream = new GZipOutputStream(outStream))
                using (var tarArchive = TarArchive.CreateOutputTarArchive(gzoStream))
                {
                    foreach (string path in Paths)
                    {
                        tarArchive.RootPath = Path.GetDirectoryName(path);
                        var tarEntry = TarEntry.CreateEntryFromFile(path);
                        tarEntry.Name = Path.GetFileName(path);
                        tarArchive.WriteEntry(tarEntry, true);
                    }       
                }
            }
            catch(Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }

        public void ArchivateFolder(string Path)
        { try
            {
                string savepath = "";
                DirectoryInfo directory = new DirectoryInfo(Path);
                FileInfo[] filesInDirectory = directory.GetFiles();
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Save archive";
                saveFile.FileName = "New Archive";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    savepath = saveFile.FileName;
                }
                String tarArchiveName = @"" + savepath + ".tar.gz";
                using (Stream targetStream = new GZipOutputStream(File.Create(tarArchiveName)))
                {
                    using (TarArchive tarArchive = TarArchive.CreateOutputTarArchive(targetStream, TarBuffer.DefaultBlockFactor))
                    {
                        
                        foreach (FileInfo fileToBeTarred in filesInDirectory)
                        {
                            TarEntry entry = TarEntry.CreateEntryFromFile(fileToBeTarred.FullName);
                            tarArchive.WriteEntry(entry, true);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex));}
        }
        //todo changing metadata
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
                FileInfo tarFileInfo = new FileInfo(Path);
                DirectoryInfo targetDirectory = new DirectoryInfo(Convert.ToString(Directory.GetParent(Path)));
                if (!targetDirectory.Exists)
                {
                    targetDirectory.Create();
                }
                using (Stream sourceStream = new GZipInputStream(tarFileInfo.OpenRead()))
                {
                    using (TarArchive tarArchive = TarArchive.CreateInputTarArchive(sourceStream, TarBuffer.DefaultBlockFactor))
                    {
                        tarArchive.ExtractContents(targetDirectory.FullName);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(Convert.ToString(ex)); }
        }
        //todo adding to archive
        public void Fragmentation(string Path)
        {
            throw new NotImplementedException();
        }
        //todo Checking archive
        public void TestProblems(string Path)
        {
           
            ZipFile.CheckZip(Path);
        }

       
      
    }
}

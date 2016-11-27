using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator_STP_Project_.Archivation
{
   public interface IComand
    {
        //Заархивировать файл
        void ArchivateFile(List<string> Paths);
        //Заархивировать папку
        void ArchivateFolder(string Path);
        //Розархивировать
        void Dearchivate(string Path);
        //Изменение метаданых //Розчет МД5 хеша
        void ChangeMetaData(string Path);
        //Проверка чексум
        void CheckSum(string Path);
        //Тестирование на повреждение
        void TestProblems(string Path);
        //Розбиение архвива на части
        void Fragmentation(string Path);
       
       
    
    }
}

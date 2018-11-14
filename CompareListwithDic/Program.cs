using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareListwithDic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> oldFileList = new DirectoryInfo("")
                .GetFiles().Where(info => info.Extension.ToUpper() == ".TXT" 
                && info.Name.ToLower().StartsWith("")).OrderByDescending(x => x.LastWriteTime).ToList();
         
        }
        public static List<string> comparisonTextRow(string filePathNew, string filePathOld)
        {
            List<string> result = null;
            if (string.IsNullOrWhiteSpace(filePathNew))
            {
                return result;
            }
            if (!File.Exists(filePathNew))
            {
                return result;
            }
            if (string.IsNullOrWhiteSpace(filePathOld) || !File.Exists(filePathOld))
            {
                return File.ReadAllLines(filePathNew).ToList();
            }
            else
            {
                List<string> oldTextRows = File.ReadAllLines(filePathOld).ToList();
                List<string> newTextRows = File.ReadAllLines(filePathNew).ToList();
                return newTextRows.Except(oldTextRows).ToList();
            }
        }
    }
}

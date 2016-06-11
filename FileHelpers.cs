using System;
using System.IO;

namespace DotnetHelpers
{
    class FileHelpers
    {
        public bool IsHidden(string file)
        {
            bool result;
            FileInfo fi = new FileInfo(file);
            if (fi.Attributes == FileAttributes.Hidden)
                result = true;
            else
                result = false;
            return result;
        }
        public void HideFile(string file)
        {
            if (IsHidden(file))
            { }
            else
            {
                FileInfo fi = new FileInfo(file);
                fi.Attributes = FileAttributes.Hidden;
            }
        }
        public void WriteOnTheLine(string file, string text, int linenumber)
        {
            string[] arrLine = File.ReadAllLines(file);
            arrLine[linenumber - 1] = text + Environment.NewLine;
            File.WriteAllLines(file, arrLine);
        }




    }
}

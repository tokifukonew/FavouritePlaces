using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FavouritePlaces.Models
{
    public class Settings
    {
        private string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public IEnumerable<string> GetFilesList()
        {
            return Directory.GetFiles(_folderPath).Select(f => Path.GetFileName(f));
        }
        public string GetSizeFile(string filePath)
        {
            var fileInfo = new FileInfo(Path.Combine(_folderPath, filePath));
            string sLen = fileInfo.Length.ToString();
            if (fileInfo.Length >= (1 << 20))
                sLen = string.Format("{0}Mb", (fileInfo.Length / 1024) / 1024);
            else
            if (fileInfo.Length >= (1 << 10))
                string.Format("{0} kb", fileInfo.Length / 1024);
            else
                sLen = string.Format("{0} b", fileInfo.Length);
            return sLen;
        }
        public string GetFileChange(string filePath)
        {
            var fileInfo = new FileInfo(Path.Combine(_folderPath, filePath));
            string sChange = fileInfo.LastWriteTime.ToString();
            return sChange;
        }


        public class File
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Size { get; set; }
            public string Change { get; set; }
            public override string ToString()
            {
                return $"{this.Value}";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class FileParser
    {
        private FileInfo file;
        private string path;
        public IParse parser { private get; set; }
        public string FileName { get; private set; }
        public long FileSize { get; private set; }
        public FileParser(string path, IParse parser)
        {
            this.parser = parser;
            this.path = path;
            CheckFile();
        }
        private void CheckFile()
        {
            if (this.parser == null)
            {
                throw new Exception("Parser is not defined");
            }
            file = new FileInfo(path);
            if (!file.Exists)
            {
                throw new Exception("File is not exists");
            }
            if (file.Extension != ".txt" && file.Extension != ".doc" && file.Extension != ".docx")
            {
                throw new Exception("The file is not text");
            }
            FileName = file.Name;
            FileSize = file.Length;
        }
        public KeyValuePair<String, int> TryParse()
        {
            return parser.Parse(file);
        }
    }
}

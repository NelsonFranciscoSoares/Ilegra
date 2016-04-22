using System.Collections.Generic;
using System.IO;
using Ilegra.Core.Interfaces;

namespace Ilegra.Infrastructure.FileReader
{
    public class FileReader : IDataReader
    {
        private string FilePath { get; set; }
        private StreamReader Reader { get; set; }

        public FileReader(string filePath)
        {
            this.FilePath = filePath;
            this.Reader = new StreamReader(filePath);
        }
        
        public Dictionary<int, string> ReadFile()
        {
            var line = string.Empty;
            var index = 0;
            var dictionary = new Dictionary<int, string>();

            while ((line = this.Reader.ReadLine()) != null)
            {
                dictionary.Add(index++, line);
            }

            return dictionary;
        }

        public void Dispose()
        {
            this.Reader.Dispose();
        }
    }
}
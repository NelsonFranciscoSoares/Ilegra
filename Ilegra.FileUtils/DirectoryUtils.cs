using System;
using System.Collections.Generic;
using System.IO;

namespace Ilegra.FileUtils
{
    public static class DirectoryUtils
    {
        private const string DAT_FILE_EXTENSION = "*.DAT";

        public static IEnumerable<string> GetDatFilesByDirectory(string path)
        {
            if(Directory.Exists(path) == false)
                throw new Exception("Directory doesn't exist");

            return Directory.GetFiles(path, DAT_FILE_EXTENSION);
        }
    }
}

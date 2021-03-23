using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace fileManagerTaskAPI.Models
{
    public class publicHelper
    {
        public static bool checkFile(string fullPath)
        {
            FileInfo file = new FileInfo(fullPath);
            return file.Exists;
        }

        public static void deleteFile(string fullPath)
        {
            FileInfo file = new FileInfo(fullPath);
            file.Delete();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Streams
{
    public class FileHandler
    {
        public string FileName
        {
            get;
            set;
        }
        public bool FileExists()
        {
            return File.Exists(FileName);
        }
        public void CreateFile()
        {
            if (!FileExists())
            {
                File.Create(FileName);
            }
        }
        public void DeleteFile()
        {
            if (FileExists())
            {
                File.Delete(FileName);
            }
        }
    }
}

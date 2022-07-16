using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CustomExceptions
{
    public class FilePathException : FileNotFoundException
    {
        public FilePathException(string message, string file, Exception innerException) :base(message, file, innerException)
        {
            throw new Exception(String.Format("{0} : {1} \r\n", message, file), innerException.InnerException);
        }    
        
    }
}

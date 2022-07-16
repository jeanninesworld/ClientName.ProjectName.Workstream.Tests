using System.Runtime.Serialization;

namespace Framework.Helpers
{
    [Serializable]
    internal class ExceptionHandler : Exception
    {
        private string v;
        private string filePath;
        private FileNotFoundException fileNotFoundException;
        private Exception? innerException;

        public ExceptionHandler()
        {
        }

        public ExceptionHandler(string? message) : base(message)
        {
        }

        public ExceptionHandler(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public ExceptionHandler(string v, string filePath, FileNotFoundException fileNotFoundException, Exception? innerException)
        {
            this.v = v;
            this.filePath = filePath;
            this.fileNotFoundException = fileNotFoundException;
            this.innerException = innerException;
        }

        protected ExceptionHandler(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
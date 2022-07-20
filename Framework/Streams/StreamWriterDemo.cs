using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Streams
{
    public class StreamWriterDemo : FileHandler
    {
        StreamWriter? writer = null;
        public StreamWriterDemo()
        { }


        public StreamWriterDemo(string path, string toWrite)
        {
            using (writer = new StreamWriter(path))
            {
                writer.WriteLine(toWrite);
            }
        }
        public StreamWriter GetSw(string path)
        {
            writer = new StreamWriter(path);
            return writer;
        }
        public void Dispose()
        {
            try
            {
                writer.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}

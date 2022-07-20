using Framework.Streams;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UITests
{
    [TestFixture]
    public class StreamReaderTest : StreamWriterDemo
    {

    [Test]
    public void FileHandling()
        {
            StreamWriterDemo writer = new StreamWriterDemo();
            StreamWriter sw = writer.GetSw(@"c:\temp\hola.txt");
            sw.WriteLine("Hello from program");
            writer.Dispose();
        }
    }
}



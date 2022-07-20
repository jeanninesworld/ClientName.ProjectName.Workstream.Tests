using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    class Program
    {
        static void Main(String[]args)
        {
            //creates the .txt file using StreamWriter
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ExampleTTtextFile.txt"))
            {
                sw.WriteLine("Hello World.");
                sw.WriteLine("My Name is Jeannine");
                sw.WriteLine("This is my example");
                sw.WriteLine("I hope you like it.");
                sw.WriteLine("Thank you");
            }

            //Reads the file using StreamReader and displays the contents
            using (StreamReader sr = new StreamReader(@"C:\temp\ExampleTTtextFile.txt"))
            {
                string s;
                do
                {
                    s = sr.ReadLine();
                    Console.WriteLine(s);
                } while (s != null);
            }
            Console.ReadLine();

        }
    }
}

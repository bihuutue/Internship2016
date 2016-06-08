using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Updating_text
{
    class Updating_text
    {
        public static void Main()
        {
            Console.WriteLine("Began updating file");
            int count = 1;
            string path = @"C:\Tue Nguyen\trialCsharp\Updating text\Project2\Text Folder\Test.txt";
            TextWriter tw;
            if (!File.Exists(path))
            {
                File.Create(path);
                tw = new StreamWriter(path);
            }
            else
            {
                tw = new StreamWriter(path);
            }
            tw.WriteLine("The very first line!");
            tw.Close();
            tw = new StreamWriter(path, true);
            while (count <= 100)
            {
                Thread.Sleep(100);
                tw.WriteLine("The line: " + count);
                Console.WriteLine("Just Written: " + count);
                count++;
            }
            tw.Close();

            Console.WriteLine("Finished updating at: " + DateTime.Now.ToString());
            Thread.Sleep(300);
            //Console.ReadKey();
        }
    }
}

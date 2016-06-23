using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBat
{
    class OpenBat
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to batch file launcher!");
            Console.WriteLine("Please input parameter:");
            String para = Console.ReadLine();
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Tue Nguyen\\Internship2016\\Batch\\Setup.bat";
            proc.StartInfo.WorkingDirectory = "C:\\Tue Nguyen\\Internship2016\\Batch";
            proc.StartInfo.Arguments = para;
            proc.Start();
            proc.WaitForExit();
            Console.WriteLine("Program finished executing!");
            Console.ReadKey();
        }
    }
}

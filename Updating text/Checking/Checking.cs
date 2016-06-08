using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

namespace Checking
{
    class Checking
    {
        public static void Main()
        {
            string path = @"C:\Tue Nguyen\trialCsharp\Updating text\Project2\Text Folder\Test.txt";
            Console.WriteLine("Start File checking at: " + DateTime.Now.ToString());
            FileInfo file = new FileInfo(path);

            int timer = 0;
            while (timer <100)
            {
                if (!IsFileLocked(path))
                {
                    timer++;
                }
                else
                {
                    timer = 0;
                }
                Thread.Sleep(1);
            }
            Console.WriteLine("File has finished updating at: " + DateTime.Now.ToString());
            Thread.Sleep(300);
            
            //Console.ReadKey();
        }
        private static bool IsFileLocked(string fileName)
        {
            HashAlgorithm sha1 = HashAlgorithm.Create();
            FileStream stream =null;
            try
            {
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}

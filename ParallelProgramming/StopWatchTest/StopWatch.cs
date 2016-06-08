using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace StopWatchTest
{
    class StopWatch
    {
        public static void Main(string[] args)
        {
            Stopwatch threadTimer = new Stopwatch();
            Thread threadTask1 = new Thread(new ThreadStart(Task1));
            threadTask1.Start();
            threadTimer.Restart();
            while (threadTimer.Elapsed.Seconds < 2 && threadTask1.IsAlive)
            {
            }
            if (threadTask1.IsAlive)
            {
                threadTask1.Abort();
                Console.WriteLine("Task1 aborted!");
            }
            Thread threadTask2 = new Thread(new ThreadStart(Task1));
            threadTask2.Start();
            threadTimer.Restart();
            while (threadTimer.Elapsed.Seconds < 2 && threadTask2.IsAlive)
            {
            }
            if (threadTask2.IsAlive)
            {
                threadTask2.Abort();
                Console.WriteLine("Task2 aborted!");
            }
            Console.WriteLine("Program has finished");
            Console.ReadKey();
        }
        public static void Task1()
        {
            int timer = 0;
            while (true)
            {
                Console.WriteLine("Task1 is counting stars: " + timer);
                timer++;
                Thread.Sleep(100);
            }
        }
        public static void Task2()
        {
            int timer = 0;
            while (true)
            {
                Console.WriteLine("Task1 is sleeping: " + timer);
                timer++;
                Thread.Sleep(100);
            }
        }
    }
}

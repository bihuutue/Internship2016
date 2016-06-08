using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelProgramming
{
    class ParallelProgramming
    {
        public static void Main()
        {
            List<CancellationTokenSource> tokenSource = new List<CancellationTokenSource>();

            tokenSource.Add(new CancellationTokenSource());
            tokenSource[0].CancelAfter(200);
            Task task1 = Task.Factory.StartNew(() => InfiLoop(tokenSource[0]), tokenSource[0].Token);
            task1.Wait();

            Task<double> task2 = Task<double>.Factory.StartNew(() => Divide(1, 0));
            try
            {
                task2.Wait();
                Console.WriteLine(task2.Result);
            }
            catch
            {
                Console.WriteLine("Exception in Task2!");
            }

            tokenSource.Add(new CancellationTokenSource());
            tokenSource[1].CancelAfter(2000);

            Thread task3 = new Thread(new ThreadStart(finiteLoop));
            task3.Start();
            int timer = 0;
            while (timer < 20000 && task3.IsAlive)
            {
                Thread.Sleep(1);
                timer++;
            }
            if (task3.IsAlive)
            {
                //task3.Abort();
            }
            Thread.Sleep(1000);

            Console.WriteLine("Main program finished...");
            //Console.ReadKey();
        }

        public static double Divide(double a, double b)
        {
            List<int> num = new List<int>();
            return num[0] / num[1];
        }

        public static void InfiLoop(CancellationTokenSource tokenSource)
        {
            while (true)
            {
                Console.WriteLine("In infiloop...");
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Infiloop stopped...");
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public static void finiteLoop()
        {
            bool exceptionCaught = false;
            try
            {
                for (int i = 0; i < 100 * 100; i++)
                {
                    Console.WriteLine("In finite loop: " + i);
                    //if (tokenSource.IsCancellationRequested)
                    //{
                    //    Console.WriteLine("Long loop stopped...");
                    //    break;
                    //}
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                Console.WriteLine("Thread cancellation received!...");
                exceptionCaught = true;
            }
            finally
            {
                if (exceptionCaught)
                {
                    Console.WriteLine("Thread cancelled!");
                }
            }
            Console.WriteLine("Zombie coming...");
        }
    }
}

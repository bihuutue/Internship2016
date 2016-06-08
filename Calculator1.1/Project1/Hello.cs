using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Hello
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Please input 2 integers, if more, please write M");
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int a = Convert.ToInt32(Console.Read());
            //Console.Read();
            //int b = Convert.ToInt32(Console.Read());
            string input = Console.ReadLine();
            string[] tokens = input.Split();
            Calculate c = new Calculate();

            if (tokens[0] == "M")
            {
                Console.WriteLine("Please write the list of integers: ");
                string[] retryList = {};
                while (retryList.Length % 2 != 1)
                {
                    Console.WriteLine("Input starts and ends with integers, separated by blank space!");
                    input = Console.ReadLine();
                    retryList = input.Split();
                }
                List<int> numList = new List<int>();
                for (int i = 0; i < retryList.Length; i++)
                {
                    numList.Add(Convert.ToInt32(retryList[i]));
                }
                Console.WriteLine("The answer is: {0}", c.plus(numList));
                Console.WriteLine("Would you like to try other functions? Press - *");
                input = Console.ReadLine();
                int ans2 = 0;
                bool check = true;
                switch (input)
                {
                    case "-":
                        ans2 = c.minus(numList);
                        break;
                    case "*":
                        ans2 = c.time(numList);
                        break;
                    default:
                        check = false;
                        break;
                }
                if (check)
                {
                    Console.WriteLine("The answer is: {0}", ans2);

                }
                Console.WriteLine("Thanks for trying");
            }
            else
            {
                int a = Convert.ToInt32(tokens[0]);
                int b = Convert.ToInt32(tokens[1]);
                Console.WriteLine("Calculating: {0} + {1}", a, b);
                Console.WriteLine("The answer is: {0}", c.plus(a, b));
            }
            Console.ReadLine();
        }
    }

    class Calculate
    {
        public int plus(int a, int b)
        {
            return a + b;
        }
        public int plus(List<int> numList)
        {
            int total = 0;
            for (int i = 0; i < numList.Count(); i++)
            {
                total += numList.ElementAt(i);
            }
            return total;
        }
        public int minus(List<int> numList)
        {
            int total = 0;
            for (int i = 0; i < numList.Count(); i++)
            {
                total -= numList.ElementAt(i);
            }
            return total;
        }
        public int time(List<int> numList)
        {
            int total = 1;
            for (int i = 0; i < numList.Count(); i++)
            {
                total *= numList.ElementAt(i);
            }
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operation;

namespace Calculator
{
    public class Request
    {
        string input = null;
        string[] tokens = { };
        bool check = true;
        bool valid = true;

        public bool setValue(string input)
        {
            this.input = input;
            if (input.Split().Length == 3)
            {
                tokens = input.Split();
                return true;              
            }
            else
            {
                return false;
            }
        }
        public double getResult()
        {
            Operation.Operation op = new Operation.Operation();
            double a;
            double b;
            double ans = 0;
            List<string> opList = new List<string>(new string[] { "+", "-", "*", "/" });
            if (!opList.Contains(tokens[1]))
            {
                valid = false;
            }
            if (!Double.TryParse(tokens[0], out a))
            {
                valid = false;
            }
            if (!Double.TryParse(tokens[2], out b))
            {
                valid = false;
            }
            switch (tokens[1])
            {
                case "+":
                    ans = op.plus(a, b);
                    break;
                case "-":
                    ans = op.minus(a, b);
                    break;
                case "*":
                    ans = op.time(a, b);
                    break;
                case "/":
                    if (b != 0)
                    {
                        ans = op.divide(a, b);
                    }
                    else
                    {
                        valid = false;
                    }
                    break;
                default:
                    valid = false;
                    break;
            }
            return ans;
        }
        public bool getValid()
        {
            return valid;
        }
        public bool getCheck()
        {
            return check;
        }
        public void setCheck(bool val)
        {
            this.check = val;
        }
        public void setValid(bool val)
        {
            this.valid = val;
        }
    }
    public class Calculator
    {
        static void Main(string[] args)
        {
            Request req = new Request();
            double ans = 0;
            while (req.getCheck())
            {
                req.setValid(true);
                Console.WriteLine("Please enter the request:");
                string input = Console.ReadLine();
                while (!req.setValue(input))
                {
                    Console.WriteLine("Please enter 2 numbers separated by an operation!");
                    input = Console.ReadLine();
                }
                ans = req.getResult();
                if (req.getValid())
                {
                    Console.WriteLine("Your request result is: {0}", ans);
                }
                else
                {
                    Console.WriteLine("Your request is invalid!");
                }
                Console.WriteLine("Would you like to try again? Q to quit");
                if (Console.ReadLine().ToUpper() == "Q")
                {
                    req.setCheck(false);
                };
            }
            Console.WriteLine("Thank you for using the service!");
            Console.ReadLine();
        }
    }
}

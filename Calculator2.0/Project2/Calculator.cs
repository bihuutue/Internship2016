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
        bool check = true;
        bool valid = true;
        List<string> tokens;
        public bool setValue(string input)
        {
            this.input = input;
            List<string> opList = new List<string>(new string[] { "+", "-", "*", "/", ")", "(" });
            string[] tokenized = { };

            tokenized = input.Split();
            tokens = new List<string>(tokenized);
            double a;
            for (int i = 0; i < tokens.Count(); i++)
            {
                if (!opList.Contains(tokens[i]) && !Double.TryParse(tokens[i], out a))
                {
                    return false;
                }
            }
            return true;
        }
        public double getResult()
        {
            Operation.Operation op = new Operation.Operation();
            double a;
            double b;
            a = 0;
            b = 0;
            while (tokens.Count() > 1)
            {
                double current;
                while (tokens.Contains("*") || tokens.Contains("/"))
                {
                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        if (tokens[i] == "*" && i >=1)
                        {
                            if (Double.TryParse(tokens[i - 1], out a) && Double.TryParse(tokens[i + 1], out b))
                            {
                                current = op.time(a, b);
                                tokens[i - 1] = Convert.ToString(current);
                                //Delete both at i and i+1
                                tokens.RemoveAt(i);
                                tokens.RemoveAt(i);
                                break;
                            }
                        }
                        if (tokens[i] == "/" && i >= 1)
                        {
                            if (Double.TryParse(tokens[i - 1], out a) && Double.TryParse(tokens[i + 1], out b))
                            {
                                current = op.divide(a, b);
                                tokens[i - 1] = Convert.ToString(current);
                                //Delete both at i and i+1
                                tokens.RemoveAt(i);
                                tokens.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                while (tokens.Contains("+") || tokens.Contains("-"))
                {
                    for (int i = 0; i < tokens.Count(); i++)
                    {
                        if (tokens[i] == "+" && i >= 1)
                        {
                            if (Double.TryParse(tokens[i - 1], out a) && Double.TryParse(tokens[i + 1], out b))
                            {
                                current = op.plus(a, b);
                                tokens[i - 1] = Convert.ToString(current);
                                //Delete both at i and i+1
                                tokens.RemoveAt(i);
                                tokens.RemoveAt(i);
                                break;
                            }
                        }
                        if (tokens[i] == "-" && i >= 1)
                        {
                            if (Double.TryParse(tokens[i - 1], out a) && Double.TryParse(tokens[i + 1], out b))
                            {
                                current = op.minus(a, b);
                                tokens[i - 1] = Convert.ToString(current);
                                //Delete both at i and i+1
                                tokens.RemoveAt(i);
                                tokens.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
            return Convert.ToDouble(tokens[0]);
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
                    Console.WriteLine("Your request is invalid, please try again!");
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

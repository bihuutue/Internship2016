using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Trial
{
    class Finance
    {
        //Note: here only taxRate are shared, so they are static - others are non-static
        //Only public value can be called from main like Nam.accountName, private values can be called in this Finance class methods only
        public int income;
        public String accountName;
        private int accountNum;
        private double accountBalance;
        public static double taxRate = 0.1;
        public List<Bank> bankSide = new List<Bank>{new Bank()};

        //Constructor for a Finance object
        public Finance()
        {
            Console.WriteLine("This account has been added to the bank database for user: "+"default");
        }
        public Finance(String acountName, int acountNum, int income)
        {
            this.accountName = acountName;
            this.accountNum = acountNum;
            this.income = income;
            this.accountBalance = 0;
            Console.WriteLine("This account has been added to the bank database for user: " + accountName);
        }
        //(Non-static) Add pay for the number of unpaid months plus their bonus
        public void transferPay(int month, int bonus)
        {
            accountBalance = accountBalance + (income + bonus) * month * (1 - taxRate);
        }
        //This is a static function
        public static void bankNotice(Finance account)
        {
            Console.WriteLine();
            Console.WriteLine("Bank statement for user: " + account.accountName);
            Console.WriteLine("Account number: " + account.accountNum);
            Console.WriteLine("Acoount balance: " + account.accountBalance);
        }
    }
    class Bank
    {
        public List<int> branchID = new List<int> { 1, 2, 3 };
        public Bank() {
            Console.WriteLine("Welcome to DBS.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Reflection_Trial;

namespace Reflection_Trial
{

    class ReflectionMain
    {
        public static void Main(string[] args)
        {
            object testFinance = CreateInstance("Finance");
            Console.WriteLine(testFinance.GetType().GetProperty("taxRate"));
            Finance testFinance2 = new Finance();
            foreach (FieldInfo FI in testFinance.GetType().GetFields())
            {
                if (FI.Name == "bankSide")
                {
                    dynamic bankSide = FI.GetValue(testFinance);
                    List<Bank> bankSide1 = bankSide;
                    foreach (FieldInfo BI in bankSide[0].GetType().GetFields())
                    {
                        if (BI.Name == "branchID")
                        {
                            dynamic branchID = BI.GetValue(bankSide1[0]);
                            List<int> branchID1 = branchID;
                            foreach (int i in branchID1)
                            Console.WriteLine(i);
                        }
                    }
                   // Console.WriteLine(test);
                }
            }
            //Console.WriteLine(myPropInfo.GetValue(testFinance2, null));

            Console.ReadKey();
        }
        public static object CreateInstance(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.Name == className);
            return Activator.CreateInstance(type);
        }
    }

}

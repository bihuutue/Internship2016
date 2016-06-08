using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalVSLocal
{
    class TestVar
    {
        public static CountNum gloVar = new CountNum();
        public static void Main()
        {
            CountNum locVar = new CountNum();
            Console.WriteLine("Before:");
            Console.WriteLine(locVar.num);
            Console.WriteLine(gloVar.num);

            Console.WriteLine("After:");
            gloVar = locVar;
            gloVar.num = 7;
            locVar.num = 2;
            Console.WriteLine(locVar.num);
            Console.WriteLine(gloVar.num);
            Console.ReadKey();
        }
    }
    class CountNum
    {
        public int num = 0;
    }
}
